using System;

namespace tareaReloaded
{
    class Program
    {
        static int CalcularCocienteIteracion(int dividendo, int divisor, int cociente = 1)
        {
            if ( divisor == 0) throw new Exception();

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

            if ( divisor == 0) throw new Exception();

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
        
        /*
        static float DividirDecimalesRecursivaSinDivision(int dividendo, int divisor, int cociente = 1, string res = "") 
        {
            int resto = dividendo % divisor;
            // * Si el dividendo es 0 el cociente siempre sera 0.
            if (dividendo == 0)
            {
                return 0;
            }

            // * Si el resto es 0 el cociente sera entero.
            if (resto == 0) 
            {
                res += CalcularCocienteRecursiva(dividendo, divisor, cociente);
                float result = float.Parse(res);
                return result;
            }

            // ! Ejecuto solo la primera vez para conseguir el primer numero del cociente
            if (res == "") 
            {
                res += CalcularCocienteRecursiva(dividendo, divisor, cociente).ToString() + ",";
            }
            else 
            {
                res += CalcularCocienteRecursiva(dividendo, divisor, cociente).ToString();
            }
            
            // * Agrega 0 al resto y vuelve a calcular un nuevo resto.
            dividendo = resto * 10;
            resto = dividendo % divisor;

            return DividirDecimalesRecursivaSinDivision(dividendo, divisor, cociente, res);    
        }

        static float DividirDecimalesRecursivaSinDivision2(int dividendo, int divisor, int cociente = 1, float res = 0) 
        {
            int resto = dividendo % divisor;
            // * Si el dividendo es 0 el cociente siempre sera 0.
            if (dividendo == 0)
            {
                return 0;
            }

            // * Si el resto es 0 el cociente sera entero.
            if (resto == 0) 
            {
                res += CalcularCocienteRecursiva(dividendo, divisor, cociente);
                if (res < 100) res *= 10; 
                return res * (float) 0.01;
            }

            else 
            {
                res = res * 10 + CalcularCocienteRecursiva(dividendo, divisor, cociente) * 10;
            }
            
            // * Agrega 0 al resto y vuelve a calcular un nuevo resto.
            dividendo = resto * 10;
            resto = dividendo % divisor;

            return DividirDecimalesRecursivaSinDivision2(dividendo, divisor, cociente, res);    
        }

        */

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
                    } 
                    catch 
                    {
                        Error();
                    }   
                }

                else 
                {
                    Error();
                }
            }

            else 
            {
                Error();
            }
        }

        static void Main(string[] args)
        {
            HacerDivision();
        }
    }
}
