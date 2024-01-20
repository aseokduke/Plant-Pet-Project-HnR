#include "DHT.h"
#define DHTPIN 7 
#define DHTTYPE DHT11 
DHT dht(DHTPIN, DHTTYPE);

#define LEDPIN 11
#define LIGHTSENSORPIN A0 


void setup()
{
  Serial.begin(9600);
  pinMode(LIGHTSENSORPIN,  INPUT);
  pinMode(LEDPIN, OUTPUT);
dht.begin();

}

void loop()
{
  float reading = analogRead(LIGHTSENSORPIN); //Read light level
  float square_ratio = reading / 200.0;      //Percent of maximum value (1023)
  square_ratio = pow(square_ratio, 2.0);
//Print light level
analogWrite(LEDPIN, 255.0 * square_ratio);  //Adjust LED brightness 
Serial.print("Light: ");
Serial.println(reading);
Serial.print("\n");
  delay(2500);
  float h = dht.readHumidity();
  float t = dht.readTemperature();

//Print humidity level
Serial.print("Humidity: ");
Serial.print(h);
Serial.print("% ");
Serial.print("\n");

//Print temperature level
Serial.print("Temperature: ");
Serial.print(t);
Serial.print("C ");
Serial.print("\n");
}