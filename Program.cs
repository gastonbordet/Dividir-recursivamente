using System;

namespace tareaReloaded
{
    class Program
    {
        static int CalcularCocienteIteracion(int dividendo, int divisor, int cociente = 1)
        {
            if (divisor == 0) 
            {
                throw new Exception();
            }
            // Busco si alguno de los numeros ingresados es negativo
            bool minus = dividendo < 0 || divisor < 0;
            
            // Convierto el o los numeros negativos en positivos para operar.
            if (minus) 
            {
                dividendo = Math.Abs(dividendo);
                divisor = Math.Abs(divisor);
            }
            
            // Division
            while (dividendo - divisor > 0) 
            {   
                if (dividendo - divisor > 0)
                    cociente++;
                dividendo -= divisor;
            }

            // Si necesita decimales le resto 1 al cociente.
            if (dividendo - divisor < 0) cociente--;

            // Si el numero era negativo convierto el resultado en negativo
            return minus ? cociente * -1 : cociente; 
            
        }

        static int CalcularCocienteRecursiva(int dividendo, int divisor, int cociente = 1, bool minus = false) 
        {

            if (divisor == 0) 
            {
                throw new Exception();
            }
            // Busco si alguno de los numeros ingresados es negativo
            if (!minus) minus = dividendo < 0 || divisor < 0;
            
            // Convierto el o los numeros negativos en positivos para operar.
            if (minus) 
            {
                dividendo = Math.Abs(dividendo);
                divisor = Math.Abs(divisor);
            }

            if (dividendo - divisor <= 0) 
            {
                // Si el resto no es 0 necesito restarle un numero
                if (dividendo - divisor < 0) cociente--;

                // Si el numero era negativo convierto el resultado en negativo
                return minus ? cociente * -1 : cociente; 
            }

            cociente++;
            return CalcularCocienteRecursiva(dividendo - divisor, divisor, cociente, minus);
        }
        
        static float DividirConDecimales(int dividendo, int divisor, int cociente = 1, float res = 0) 
        {
            int ultimoNumero = 0;

            // Si el resto es 0 no hace falta calcular decimales 
            if (dividendo % divisor == 0) return CalcularCocienteIteracion(dividendo, divisor);

            // Calculo para decimales
            while (res < 100000) 
            {
                int resto = dividendo % divisor;
                int nuevoCociente = CalcularCocienteIteracion(dividendo, divisor, cociente);

                // Valido que el resultado no sea periodico
                if (ultimoNumero == nuevoCociente) return res * (float) 0.01;

                // * Si el resto es 0 el cociente sera entero.
                if (resto == 0) 
                {
                    res += nuevoCociente;
                    if (res < 100) res *= 10; 
                    return res * (float) 0.01;
                }

                else 
                {
                    res = res * 10 + nuevoCociente * 10;
                }
                
                // * Agrega 0 al resto y vuelve a calcular un nuevo resto.
                dividendo = resto * 10;
                resto = dividendo % divisor;
                ultimoNumero = nuevoCociente;
            }   

            return res * (float) 0.01;
        }

        static void Error()
        {
            Console.WriteLine("Hubo un error con algun numero. Intente nuevamente ");
            HacerDivision();
        }

        static void HacerDivision() 
        {
            Console.WriteLine("Ingrese dividendo: ");
            int dividendo = 0;
            int divisor = 0;
            if (int.TryParse(Console.ReadLine(), out dividendo)) 
            {
                Console.WriteLine("Ingrese un divisor");
                if (int.TryParse(Console.ReadLine(), out divisor)) 
                {
                    try 
                    {
                        Console.WriteLine("Division iterativa: " + CalcularCocienteIteracion(dividendo, divisor));
                        Console.WriteLine("Division recursiva: " + CalcularCocienteRecursiva(dividendo, divisor));
                        Console.WriteLine("Division con decimales: " + DividirConDecimales(dividendo, divisor));
                    } 
                    catch 
                    {
                        Error();
                    }   
                }

                else Error();
            }
            
            else Error();
        }

        static void Main(string[] args)
        {
            HacerDivision();
        }
    }
}
