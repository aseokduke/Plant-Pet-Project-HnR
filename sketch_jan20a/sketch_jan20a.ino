#include "DHT.h"

#define DHTPIN 7
#define DHTTYPE DHT11
DHT dht(DHTPIN, DHTTYPE);

#define LEDPIN 11
#define LIGHTSENSORPIN A0

void setup()
{
  Serial.begin(9600);
  pinMode(LIGHTSENSORPIN, INPUT);
  pinMode(LEDPIN, OUTPUT);
  dht.begin();
}

void loop()
{
  // Read light level
  float reading = analogRead(LIGHTSENSORPIN);
  float square_ratio = reading / 200.0;
  square_ratio = pow(square_ratio, 2.0);
  analogWrite(LEDPIN, 255.0 * square_ratio); // Adjust LED brightness

  // Print light level
  Serial.print("light:");
  Serial.print(reading);
  Serial.print(",");

  // Read humidity and temperature
  float h = dht.readHumidity();
  float t = dht.readTemperature();

  // Print humidity and temperature
  Serial.print("humidity:");
  Serial.print(h);
  Serial.print(",");

  Serial.print("temperature:");
  Serial.println(t);

  delay(2500);
}

