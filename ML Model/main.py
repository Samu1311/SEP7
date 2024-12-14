from flask import Flask, request, jsonify
import tensorflow as tf
import numpy as np
import os
import joblib
import logging

app = Flask(__name__)

# Configure logging
logging.basicConfig(level=logging.DEBUG)

# Load the diabetes model
diabetes_model_path = os.path.join(os.path.dirname(__file__), 'Diabetes', 'diabetes_model.h5')
diabetes_model = tf.keras.models.load_model(diabetes_model_path)

# Load the diabetes scaler
diabetes_scaler_path = os.path.join(os.path.dirname(__file__), 'Diabetes', 'diabetes_scaler.pkl')
diabetes_scaler = joblib.load(diabetes_scaler_path)

# Load the heart model
heart_model_path = os.path.join(os.path.dirname(__file__), 'Heart', 'heart_model.h5')
heart_model = tf.keras.models.load_model(heart_model_path)

# Load the heart scaler
heart_scaler_path = os.path.join(os.path.dirname(__file__), 'Heart', 'heart_scaler.pkl')
heart_scaler = joblib.load(heart_scaler_path)

@app.route('/predict_diabetes', methods=['POST'])
def predict_diabetes():
    data = request.json
    # Assuming the input is a list of features
    input_data = np.array([data['features']])
    # Scale the input data
    input_data_scaled = diabetes_scaler.transform(input_data)
    logging.debug(f"Scaled input data for diabetes: {input_data_scaled}")  # Log the scaled data
    prediction = diabetes_model.predict(input_data_scaled)
    # Round the prediction to get binary output
    prediction_rounded = np.round(prediction).astype(int)
    return jsonify({'prediction': prediction_rounded.tolist()})

@app.route('/predict_heart', methods=['POST'])
def predict_heart():
    data = request.json
    # Assuming the input is a list of features
    input_data = np.array([data['features']])
    # Scale the input data
    input_data_scaled = heart_scaler.transform(input_data)
    logging.debug(f"Scaled input data for heart: {input_data_scaled}")  # Log the scaled data
    prediction = heart_model.predict(input_data_scaled)
    # Round the prediction to get binary output
    prediction_rounded = np.round(prediction).astype(int)
    return jsonify({'prediction': prediction_rounded.tolist()})

if __name__ == '__main__':
    app.run(debug=True, host='0.0.0.0', port=5000)