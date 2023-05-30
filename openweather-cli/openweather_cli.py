import argparse
import requests
import json
from tabulate import tabulate

def get_weather(city, api_key):
    base_url = f"http://api.openweathermap.org/data/2.5/weather?q={city}&appid={api_key}"
    response = requests.get(base_url)
    data = response.json()
    if data["cod"] != "404":
        main = data["main"]
        weather = data["weather"][0]["description"]
        temperature = main['temp'] - 273.15
        wind = data["wind"]
        clouds = data["clouds"]

        table_data = [
            ["City", "Weather", "Temperature (°C)"],
            [city, weather, temperature],
            [],
            ["Main Parameters"],
            ["Temperature", f"{main['temp']} K"],
            ["Feels Like", f"{main['feels_like']} K"],
            ["Minimum Temperature", f"{main['temp_min']} K"],
            ["Maximum Temperature", f"{main['temp_max']} K"],
            ["Pressure", f"{main['pressure']} hPa"],
            ["Humidity", f"{main['humidity']}%"],
            [],
            ["Wind Parameters"],
            ["Wind Speed", f"{wind['speed']} m/s"],
            ["Wind Degree", wind["deg"]],
            [],
            ["Cloud Parameters"],
            ["Cloudiness", f"{clouds['all']}%"],
        ]
        print(tabulate(table_data, headers="firstrow", tablefmt="grid"))
    else:
        print("Invalid city name, please check your input")

def main():
    parser = argparse.ArgumentParser()
    parser.add_argument("--city", help="City name to get the weather forecast", required=True)
    parser.add_argument("--key", help="API key for OpenWeatherMap", required=True)
    args = parser.parse_args()

    get_weather(args.city, args.key)

if __name__ == "__main__":
    main()
