/*//Pisca LED no pino 13 do Arduino
// Define o pino do LED
const int ledPin = 13;

void setup() {
  // Inicializa o pino do LED como saída
  pinMode(ledPin, OUTPUT);
  
  // Inicializa a comunicação serial
  Serial.begin(9600);
}

void loop() {
  // Liga o LED
  digitalWrite(ledPin, HIGH);
  
  // Escreve no monitor serial que o LED está aceso
  Serial.println("LED aceso");
  
  // Aguarda 5 segundos
  delay(5000);
  
  // Desliga o LED
  digitalWrite(ledPin, LOW);
  
  // Escreve no monitor serial que o LED está apagado
  Serial.println("LED apagado");
  
  // Aguarda 5 segundos
  delay(5000);
}
====================================================================================
*/
/*//Sensor de Temperatura no pino A0 do Arduno
// Define o pino onde o sensor LM35 está conectado
const int sensorPin = A0;

void setup() {
  // Inicializa a comunicação serial
  Serial.begin(9600);
}

void loop() {
  // Lê o valor analógico do sensor LM35
  int sensorValue = analogRead(sensorPin);
  
  // Converte o valor lido para tensão (em volts)
  float voltage = sensorValue * (5.0 / 1023.0);
  
  // Converte a tensão para temperatura em graus Celsius
  float temperature = voltage * 100.0;
  
  // Exibe a temperatura no monitor serial
  Serial.print("Temperatura: ");
  Serial.print(temperature);
  Serial.println(" °C");
  
  // Aguarda 1 segundo antes de fazer a próxima leitura
  delay(1000);
}
*/
const int pino_A0 = A0;  // Define o pino analógico A0
const int ledPin = 13;   // Pino do LED (ajuste conforme necessário)
bool ledEstado = false;  // Estado inicial do LED

void setup() {
  Serial.begin(9600);        // Inicia a comunicação serial
  pinMode(LED_BUILTIN, OUTPUT);  
  pinMode(ledPin, OUTPUT);    // Define pino do LED como saída
  digitalWrite(ledPin, LOW);  // Garante que o LED inicie apagado
}

void loop() {
  // Verifica se há dados disponíveis na Serial
if (Serial.available()) {
  String comando = Serial.readStringUntil('\n'); // Lê até nova linha
  comando.trim(); // Remove espaços extras

  if (comando == "L") {
    digitalWrite(ledPin, HIGH); // Liga o LED
  } else if (comando == "D") {
    digitalWrite(ledPin, LOW);  // Desliga o LED
  }
}

  // Lê o valor bruto do A0 (0 a 1023)
  int leitura_A0 = analogRead(pino_A0);
  float tensao_A0 = leitura_A0 * (5.0 / 1023.0); // Converte para tensão

  // Envia os dados para o C#
  //Serial.print("Leitura A0: ");
  Serial.println(leitura_A0);
 // Serial.print(" | Tensao: ");
  //Serial.print(tensao_A0, 2);
  //Serial.println("");

  delay(1000);  // Espera 1 segundo entre leituras
}
