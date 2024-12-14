import requests

# Define the URL of the Flask API endpoint for heart disease prediction
url = 'http://localhost:5000/predict_heart'

# Define test inputs
test_inputs = [
    {"features": [60, 1, 130, 250, 0, 150, 0, 2.3, 1, 1, 0, 0, 0, 0, 1, 0, 0, 1]},  # Likely "YES"
    {"features": [25, 0, 120, 200, 0, 170, 0, 1.0, 0, 0, 1, 0, 0, 0, 0, 1, 1, 0]},  # Likely "NO"
    {"features": [55, 1, 140, 240, 1, 130, 1, 3.5, 1, 0, 0, 1, 0, 1, 0, 0, 0, 0]},  # Likely "YES"
    {"features": [30, 0, 110, 180, 0, 160, 0, 0.5, 0, 0, 0, 0, 1, 0, 1, 0, 1, 0]},  # Likely "NO"
    {"features": [65, 1, 150, 280, 1, 120, 1, 4.0, 1, 1, 0, 0, 0, 1, 0, 0, 0, 1]},  # Likely "YES"
    {"features": [20, 0, 100, 190, 0, 180, 0, 0.2, 0, 0, 1, 0, 0, 0, 0, 1, 1, 0]}   # Likely "NO"
]

# Send requests to the Flask API and print the responses
for i, input_data in enumerate(test_inputs):
    response = requests.post(url, json=input_data)
    if response.status_code == 200:
        print(f"Input {i+1}: {input_data['features']}")
        print(f"Prediction: {response.json()['prediction']}")
    else:
        print(f"Error for input {i+1}: {response.status_code} - {response.text}")