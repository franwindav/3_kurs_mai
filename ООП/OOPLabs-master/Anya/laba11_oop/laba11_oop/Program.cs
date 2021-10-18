using System;

namespace laba11_oop
{
    class Program
    {
        static void Main(string[] args)
        {
            Vector3D v1 = new Vector3D(1, 2, 3);
            Vector3D v2 = new Vector3D(4, 5, 6);

            Vector3D v_result;

            v_result = v1 + v2;
            Console.WriteLine("Rsult of sum is {0} {1} {2}",v_result.X, v_result.Y, v_result.Z);

            v_result = v1 - v2;
            Console.WriteLine("Result of diff is {0} {1} {2}", v_result.X, v_result.Y, v_result.Z);

            v_result = v1 * v2;
            Console.WriteLine("Result of Vector Product is {0} {1} {2}", v_result.X, v_result.Y, v_result.Z);

            v_result = v1 * 3;
            Console.WriteLine("Result of Product of vector and scalar (3) is {0} {1} {2}", v_result.X, v_result.Y, v_result.Z);

            Console.WriteLine("Result of Scalar Product is {0} ", Vector3D.ScalarProduct(v1, v2));

            Console.WriteLine("Length of v1 is {0}", Vector3D.Length(v1));

            Console.WriteLine("Angle between v1 and v2 is {0} ", Vector3D.Angle(v1, v2));

            Console.Write("Is v1 eqw v2: ");
            Console.WriteLine(v1 == v2);

            Console.Write("Is v1's length eqw v2's length: ");
            Console.WriteLine(Vector3D.LengthEqw(v1, v2));

            Console.ReadKey();
        }
    }
}
