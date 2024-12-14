import requests

# Define the URL of the Flask API endpoint
url = 'http://localhost:5000/predict_diabetes'

# Define test inputs
test_inputs = [
    {"features": [1, 60.0, 1, 1, 2, 35.0, 7.5, 180]},  # Likely "YES"
    {"features": [0, 25.0, 0, 0, 0, 22.0, 5.0, 90]},   # Likely "NO"
    {"features": [1, 55.0, 1, 1, 1, 32.0, 8.0, 160]},  # Likely "YES"
    {"features": [0, 30.0, 0, 0, 0, 24.0, 5.5, 100]},  # Likely "NO"
    {"features": [1, 65.0, 1, 1, 2, 36.5, 9.0, 200]},  # Likely "YES"
    {"features": [0, 20.0, 0, 0, 0, 20.0, 4.5, 80]}    # Likely "NO"
]

# Send requests to the Flask API and print the responses
for i, input_data in enumerate(test_inputs):
    response = requests.post(url, json=input_data)
    if response.status_code == 200:
        print(f"Input {i+1}: {input_data['features']}")
        print(f"Prediction: {response.json()['prediction']}")
    else:
        print(f"Error for input {i+1}: {response.status_code} - {response.text}")