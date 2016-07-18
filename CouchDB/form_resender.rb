require 'couchrest'

DATABASE = 'mydb'
form_ids = []
f = File.open("forms_to_resend", "r")
f.each_line do |line|
	form_ids.push "form_#{line.strip}"
end
f.close

couch = CouchRest.database("http://pcdb01:5984/#{DATABASE}")
forms = couch.documents({:keys => form_ids, :include_docs => true})['rows'].collect {|cc| cc['doc']}.select { |cc| cc != nil }

forms.each do |form|
  form["outboundState"] = "Ready"
  form["outboundSenders"] = nil
  form["outboundFailures"] = nil
  form["outboundMD5s"] = nil

  begin
      puts "Saving #{form['_id']}"
      couch.save_doc(form)
    rescue => e
      puts "Failed because #{e}"
    end
end
