### Weather Forecast App
This is a simple command-line application that retrieves and displays weather information for a specified city using the OpenWeatherMap API.

#### Prerequisites
Before running the application, ensure that you have the following:

#### Python 3 installed
Required Python packages:
* argparse
* requests
* tabulate

You can install the required packages using pip:

```
pip install -r requirements.txt
```
#### Usage
To use the application, follow these steps:

* Obtain an API key from OpenWeatherMap by creating an account on their website.
* Clone this repository or download the weather_forecast.py file.
* Open a terminal or command prompt and navigate to the directory where the weather_forecast.py file is located.
* Run the following command with the required command-line parameters:

```
python weather_forecast.py --city <city_name> --key <api_key>
```
Replace `<city_name>` with the name of the city for which you want to retrieve the weather forecast. Replace `<api_key>` with your OpenWeatherMap API key.

#### Example usage:

```
python weather_forecast.py --city London --key YOUR_API_KEY
```
Make sure to replace `YOUR_API_KEY` with your actual OpenWeatherMap API key.

The application will display the weather forecast for the specified city in a tabular format in the console output.