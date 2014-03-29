class RoutesController < ApplicationController
	respond_to :json

	def test_route
		response = [
			{:long => 36.155644, :lat => -86.782767},
			{:long => 36.154076, :lat => -86.787563},
			{:long => 36.15599, :lat => -86.788829},
			{:long => 36.145083,:lat => -86.812423},
			{:long => 36.146132, :lat => -86.813183}
		]

		render :json => response
	end

	def bystepgoal
		success, unit, distance, lat, long = parseParametersForSteps(params)
		return unless success

		meters = convertDistanceToMeters distance, unit
		return unless !meters.nil?

		places = getPlaces long, lat, meters
		return unless !places.nil?

		destinations = buildDestinationList places
		return unless !destinations.nil?

		distances = getDistances({:lat => lat, :long => long}, destinations)
		return unless !distances.nil?

		destination = getNearestGoal distances, meters

		waypoints = getWaypoints({:lat => lat, :long => long}, destination[:location])
		return unless !waypoints.nil?

		render :json => [{:stuff => waypoints}]
	end

	private 

	def parseParametersForSteps(params)
		begin
			unit = params[:unit].parameterize.underscore.to_sym
		rescue
			render :json => [{:error => "no unit paramter passed"}]
			return false
		end

		begin
			distance = Float(params[:distance])
		rescue
			render :json => [{:error => "invalid distance"}]
			return false
		end

		begin
			lat = Float(params[:lat])
		rescue
			render :json => [{:error => "invalid value for lattitude"}]
			return false
		end

		begin
			long = Float(params[:long])
		rescue
			render :json => [{:error => "invalid value for longitude"}]
			return false
		end

		return true, unit, distance, lat, long
	end

	def convertDistanceToMeters(distance, unit)
		case unit
		when :steps
			return (distance/2250) * 1609.34 #average number of steps per mile * meters per mile
		when :meters
			return distance
		when :miles
			return distance * 1690.34
		else
			render :json => [{:error => "couldn't convert supplied distance to meters"}]
			return nil
		end
	end

	def getPlaces(long, lat, meters)
		api_key = 'AIzaSyByE0ge7MGA9yXTxQBMBxwKq65y1QtjBMs'
		url = 'https://maps.googleapis.com/maps/api/place/nearbysearch/json?'

		begin
			placesURL = "#{url}location=#{lat},#{long}&radius=#{meters}&sensor=false&key=#{api_key}"
			puts "calling #{placesURL}"
			response = RestClient.get placesURL
		rescue
			render :json => [{:error => "error calling places api: #{$!}"}]
			return nil
		end

		if response.code != 200
			render :json => [{:error => "non 200 response code returned from places api call"}]
			return nil
		else
			return JSON.parse response
		end
	end

	def buildDestinationList(places)
		destinations = []

		begin
			places['results'].each do |result|
				lat = result['geometry']['location']['lat']
				long = result['geometry']['location']['lng']
				destinations.push({:lat => lat, :long => long})
			end
		rescue
			render :json => [{:error => "failed to build destinations from places"}]
			destinations = nil
		end

		return destinations
	end

	def getDistances(origin, destinations)
		url = 'https://maps.googleapis.com/maps/api/distancematrix/json?sensor=false&mode=walking&'
		url = url + "origins=#{origin[:lat]},#{origin[:long]}"
		url = url + "&destinations="

		destinations.each do |destination|
			url = url + "#{destination[:lat]},#{destination[:long]}%7C"
		end

		begin
			puts "calling: #{url[0..url.length-4]}"
			response = RestClient.get url[0..url.length-4]
		rescue
			render :json => [{:error => "error calling distance matrix api"}]
			puts "#{$!}"
			return nil
		end

		#check status flag
		if response.code != 200
			render :json => [{:error => "non 200 response code returned from distance matrix api call"}]
			return nil
		else			
			distances = []

			begin
				results = JSON.parse(response)
				for i in 0..(destinations.length-1)
					distances.push({:location => destinations[i], :distance => results['rows'][0]['elements'][i]['distance']['value']})
				end
			rescue
				render :json => [{:error => "error parsing distance matrix result"}]
				return nil
			end

			return distances.sort {|x, y| x[:distance] <=> y[:distance]}
		end
	end

	def getNearestGoal(distances, goal)
		for i in 0..(distances.length-1)
			if distances[i][:distance] >= goal
				if i == 0 || distances[i][:distance] == goal
					return distances[i]
				else
					lesser = goal - distances[i-1][:distance]
					greater = distances[i][:distance] - goal

					if(lesser > greater)
						return distances[i]
					else
						return distances[i-1]
					end
				end
			end
		end
	end

	def getWaypoints(origin, destination)
		url = "https://maps.googleapis.com/maps/api/directions/json?mode=walking&sensor=false&origin=#{origin[:lat]},#{origin[:long]}&destination=#{destination[:lat]},#{destination[:long]}"

		begin
			puts "calling #{url}"
			response = RestClient.get url
		rescue
			render :json => [{:error => "error calling directions api: #{$!}"}]
			return nil
		end

		if response.code != 200
			render :json => [{:error => "non 200 response code returned from directions api call"}]
			return nil
		else
			waypoints = [].push(origin)
			begin
				JSON.parse(response)['routes'][0]['legs'].each do |leg|
					leg['steps'].each do |step|
						waypoints.push({:lat => step['start_location']['lat'], :long => step['start_location']['lng']})
						waypoints.push({:lat => step['end_location']['lat'], :long => step['end_location']['lng']})
					end
				end
			rescue
				render :json => [{:error => "error parsing directions api response"}]
				return nil
			end

			return waypoints
		end
	end
end