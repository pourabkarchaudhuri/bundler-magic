## URL Shortener
This is a complete URL-shortening web application, written in Ruby using the Sinatra framework.

### Overview
This application allows you to create short, easy-to-share URLs from longer ones. You can run it from the command line and access it at `http://localhost:4567/`

This application was developed by Team Geek Squad, for CodeGladiators 2023 Microsoft Copilot Hackathon.

### Dependencies
* Ruby
* Sinatra
* ActiveRecord

### Getting Started
##### Prerequisites
You will need Ruby installed on your machine along with the Sinatra and ActiveRecord gems. If not already installed, you can install these gems by running the following command in your terminal:
```
gem install eventmachine --platform ruby
bundle install
```
Running the Application
You can run this application by executing the script from the command line. From the directory containing your script, run:

```
ruby url_shortener.rb
```

This will start a Sinatra server, typically at `http://localhost:4567/`. You can navigate to this URL in your web browser to interact with the application.

##### Features
* Home Page: The home page allows users to enter URLs to be shortened.
* Create New Short URL: The application allows users to create new short URLs. If a URL has been shortened before, the application will return the previously shortened URL.
* CSS Stylesheet: The application provides a CSS stylesheet for customization of appearance.
* URL Redirection: When a user visits a shortened URL, they are automatically redirected to the original URL.

##### Models
This application uses SQLite3 as its database and ActiveRecord as the ORM. The Link model is used to store and retrieve shortened URLs. The Link table includes a url field, a seen field (representing the number of times a link has been followed), and a created_at timestamp.

##### Helpers
The application includes a number of helper methods that are used in route handlers and views. These methods handle tasks such as HTML and URI escaping, returning the root URL for the site, pluralizing words, truncating text, and creating a browser link for posting the current URL to the application.

##### Views
The views for this application are embedded in the main script, using Haml for markup and Sass for CSS. There are three views: new (for creating a new short URL), show (for displaying a short URL), and layout (the main layout for the site).