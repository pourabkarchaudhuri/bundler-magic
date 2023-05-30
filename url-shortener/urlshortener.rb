require 'rubygems'
require 'sinatra'
require 'sequel'

# Base36 encoded
BASE = 36

configure do
  DB = Sequel.sqlite
  DB.create_table :tinyurls do
    primary_key :id
    String :url
  end
end

get '/' do
  # Form for entering a fatty URL
  <<-end_form
  <html>
    <head>
      <style>
        body {
          font-family: Arial, sans-serif;
          display: flex;
          flex-direction: column;
          justify-content: center;
          align-items: center;
          height: 100vh;
          background-color: #f5f5f5;
        }

        h1 {
          color: #333;
        }

        form {
          display: flex;
          justify-content: center;
          align-items: center;
          gap: 10px;
        }

        input[type="text"] {
          padding: 10px;
          width: 300px;
          border: 1px solid #aaa;
          border-radius: 4px;
        }

        input[type="submit"] {
          padding: 10px 20px;
          border: none;
          border-radius: 4px;
          background-color: #007bff;
          color: white;
          cursor: pointer;
        }

        input[type="submit"]:hover {
          background-color: #0056b3;
        }
      </style>
    </head>
    <body>
      <h1>URL Shortener</h1>
      <form method='post'>
        <input type="text" name="url" placeholder="Enter your URL here">
        <input type="submit" value="Shorten URL">
      </form>
    </body>
  </html>
  end_form
end

post '/' do
  # Put the fatty URL in the database and display
  items = DB[:tinyurls]
  id = items.insert(:url => params[:url])
  url = request.url + id.to_s(BASE)
  "Your shortened url is: <a href='#{url}'>#{url}</a>"
end

get '/:tinyid' do
  # Resolve the tiny URL
  items = DB[:tinyurls]
  id = params[:tinyid].to_i(BASE)
  url = items.first(:id => id)
  redirect url[:url]
end