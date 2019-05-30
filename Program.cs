using System;

namespace tareaReloaded
{
    class Program
    {
        static int CalcularCocienteIteracion(int dividendo, int divisor, int resto, int cociente = 1)
        {
            while (dividendo - divisor > 0) 
            {   if (dividendo - divisor > 0)
                    cociente++;
                dividendo -= divisor;
            }

            // ! Si el resto no es 0 necesito restarle un numero para calcular el decimal.
            return resto == 0 ? cociente : cociente - 1;
        }

        static int CalcularCocienteRecursiva(int dividendo, int divisor, int resto, int cociente = 1) 
        {
            if (dividendo - divisor <= 0) 
            {
                // ! Si el resto no es 0 necesito restarle un numero para calcular el decimal.
                return resto == 0 ? cociente : cociente - 1;
            }

            cociente++;
            return CalcularCocienteRecursiva(dividendo - divisor, divisor, resto, cociente);
        }

        static float DividirDecimalesRecursiva(int dividendo, int divisor, int resto, int cociente = 1, string res = "") 
        {
            // * Si el dividendo es 0 el cociente siempre sera 0.
            if (dividendo == 0)
            {
                return 0;
            }

            // * Si el resto es 0 el cociente sera entero.
            if (resto == 0) 
            {
                res += CalcularCocienteRecursiva(dividendo, divisor, resto, cociente).ToString();
                float result = float.Parse(res.ToString());
                return result;
            }

            // ! Ejecuto solo la primera vez para conseguir el primer numero del cociente
            if (res == "") 
            {
                res += CalcularCocienteRecursiva(dividendo, divisor, resto, cociente).ToString() + ",";
            }
            else 
            {
                res += CalcularCocienteRecursiva(dividendo, divisor, resto, cociente).ToString();
            }
            
            // * Agrega 0 al resto y vuelve a calcular un nuevo resto.
            dividendo = resto * 10;
            resto = dividendo % divisor;

            return DividirDecimalesRecursiva(dividendo, divisor, resto, cociente, res);    
        }

        static void Main(string[] args)
        {
            Console.WriteLine(DividirDecimalesRecursiva(21, 4, 21%4));
            Console.WriteLine(CalcularCocienteRecursiva(8, 4, 8%4));
            Console.WriteLine(CalcularCocienteIteracion(12, 4, 12%4));
            Console.WriteLine(CalcularCocienteIteracion(13, 4, 13%4));
        }
    }
}
