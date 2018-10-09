using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/* Este programa simula un ATM con un menú que le permite al usuario consultar su saldo, retirar o depositar efectivo y cambiar su PIN
   Cuenta con un validador de PIN y al cambiarlo verifica que lo haya ingresado bien dos veces  */

namespace test
{
    class Program
    {
        public static void Main() //Creamos una función Main que sirve de login
        {
            int pin = 2018, input, intentos = 0; //Declaramos las variables que vamos a usar para el login

            while (intentos < 3) //Con un ciclo "while" le damos al usuario 3 posibilidades de ingreso de PIN, si lo ingresa bien pasa a la función "Opciones", de lo contrario se termina el programa
            {
                Console.Write("Ingrese su PIN: ");
                input = int.Parse(Console.ReadLine());
                if (pin == input) //Verificamos si el PIN ingresado es correcto para poder continuar a la función
                {
                    Console.Write("\nBienvenido");
                    Opciones(pin); //Vamos a la función "Opciones"
                    break;
                }
                intentos = intentos + 1; //Contador del ciclo "while"
            }

            if (intentos == 3)
            {
                Console.Write("Ha ingresado incorrectamente su PIN tres veces y se ha bloqueado su tarjeta");
            }

            Console.ReadKey();
        }


        public static void Opciones(int pin) //Esta función le permite al usuario elegir las opciones para operar
        {
            int saldo = 1000, eleccion; //Declaramos las variables que vamos a usar

            do //Este ciclo "do-while" permite reiniciar el menú de opciones cada vez que el usuario realiza una acción hasta que elige salir
            {
                Console.WriteLine("\nOpciones disponibles\n");
                Console.WriteLine("1. Verificar Saldo\n");
                Console.WriteLine("2. Retirar efectivo\n");
                Console.WriteLine("3. Depositar efectivo\n");
                Console.WriteLine("4. Cambiar PIN\n");
                Console.WriteLine("5. Salir\n");
                Console.Write("Ingrese la opción deseada: ");

                eleccion = int.Parse(Console.ReadLine()); //Acá asignamos el input del usuario a la variable correspondiente

                if (eleccion == 1) //Verifica la selección del user para pasar a la función correcta
                {
                    Saldo_cuenta(ref saldo); //Vamos a la función "Saldo_cuenta"
                }
                else if (eleccion == 2)
                {
                    Retirar(ref saldo); //Vamos a la función "Retirar"
                }
                else if (eleccion == 3)
                {
                    Depositar(ref saldo); //Vamos a la función "Depositar"
                }
                else if (eleccion == 4)
                {
                    Cambia_PIN(ref pin); //Vamos a la función "Cambia_PIN"
                }
                else if (eleccion != 5 && eleccion != 1 && eleccion != 2 && eleccion != 3 && eleccion != 4)
                {
                    Console.Write("La opción seleccionada no existe, inténtelo nuevamente\n");
                }
            }
            while (eleccion != 5);
            Console.WriteLine("Hasta Luego");
        }


        private static void Cambia_PIN(ref int pin) //Esta función cambia el valor del PIN (variable "int pin" declarada mas arriba)
        {
            int pin_temp1 = 1, pin_temp2 = 2; //Declaramos las variables que vamos a usar

            while (pin_temp1 != pin_temp2) //El ciclo le pide al usuario dos veces el PIN y si coinciden lo asigna a la variable "int pin" como su nuevo PIN
            {
                Console.Write("Ingrese el nuevo PIN: ");
                pin_temp1 = int.Parse(Console.ReadLine());

                Console.Write("Reingrese el nuevo PIN: ");
                pin_temp2 = int.Parse(Console.ReadLine());

                if (pin_temp1 == pin_temp2) //verifica si los PINs ingresados coinciden, y si son iguales los asigna
                {
                    pin = pin_temp1;
                    Console.Write("Su PIN ha sido actualizado\n");
                    Console.WriteLine("------------------------------\n");
                    break;
                }

                Console.WriteLine("Los PINs ingresados no coinciden, inténtelo nuevamente\n");
            }
        }


        public static int Saldo_cuenta(ref int saldo)  //Función para verificar el saldo de la cuenta (valor de la variable "int saldo")
        {
            Console.WriteLine("\nSu saldo es de : ${0} ", saldo);
            Console.WriteLine("------------------------------\n");
            return saldo;
        }


        public static int Depositar(ref int saldo) //Función para agregar saldo (incrementa el valor de la variable "int saldo")
        {
            int depositar; //Declaramos las variables que vamos a usar

            Console.Write("\nIngrese la cantidad a depositar: $");

            depositar = int.Parse(Console.ReadLine());

            saldo = saldo + depositar;  //Asigna el nuevo saldo

            Console.WriteLine("Su saldo actualizado es de: ${0}", saldo);
            Console.WriteLine("------------------------------\n");
            return saldo;
        }


        public static int Retirar(ref int saldo)  //Función para retirar dinero (valor de la variable "int saldo")
        {
            int retirar; //Declaramos las variables que vamos a usar

            Console.Write("\nIngrese la cantidad a retirar: $");
            retirar = int.Parse(Console.ReadLine());

            if (retirar % 100 != 0) //Verifica si la cantidad elegida es múltiplo de 100
            {
                Console.WriteLine("\nDebe ingresar múltiplos de 100");
            }

            else if (retirar > saldo) //Verifica si el valor de la variable "retirar" es mayor que "saldo"
            {
                Console.WriteLine("\nSaldo insuficiente");
            }

            else //Si no se cumplen los dos requerimientos anteriores permite hacer el retiro de dinero
            {
                saldo = saldo - retirar;
                Console.WriteLine("\n\nRetire el dinero");
                Console.WriteLine("\nSu saldo actualizado es: ${0}", saldo);
                Console.WriteLine("------------------------------\n");
            }
            return saldo;
        }
    }
}
