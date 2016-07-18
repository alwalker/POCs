require 'couchrest'

customers = []
f = File.open("customers", "r")
f.each_line do |line|
	customers.push line.strip
end
f.close

customers.each do |customer|
	couch = CouchRest.database("http://admin:[password]@pcdb01:5984/#{customer}")

	begin
		all_users = couch.view('user/all', {:include_docs => true})['rows'].collect {|row| row['doc']}
	rescue => e
		puts "Error gettings users for #{customer}: #{e}"
		next
	end

	all_users.each do |user|
		user['deactivated'] = true
		user['hashed_password'] = 'bananas'

		begin
			couch.save_doc(user)
			puts "Deactivated #{user['_id']} for #{customer}"
		rescue => e
			puts "Error saving #{user['_id']} for #{customer}: #{e}"
		end
	end
end