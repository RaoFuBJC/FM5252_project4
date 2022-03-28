namespace assignment4
{
    class Program
    {
        static void Main(string[] args)
        {   
            Console.Write("Enter the number of distribution or pairs you want:");
            int num1 = Convert.ToInt32(Console.ReadLine());

            Console.Write("Please choice one of the following method you want to use(sum12, BoxMuller, Polar, CorrlatedGaussian):");
            string choice = Console.ReadLine();

            if(choice=="sum12")
            {
                foreach( var item in Sum12(num1))
                {
                    Console.WriteLine(item);
                }
            }
            if(choice=="BoxMuller")
            {
                foreach( var pairs in BoxMuller(num1))
                {
                    Console.WriteLine(pairs);
                }
            }
            if(choice=="Polar")
            {
                foreach(var lists in Polar(num1))
                {
                    Console.WriteLine(lists);
                }
            }
            if(choice=="CorrlatedGaussian")
            {
                Console.Write("Enter the corrlation you want(between-1 to 1):");
                double num2 = Convert.ToDouble(Console.ReadLine());
                foreach( var pairs in CorrGaussianways(num1,num2))
                {
                    Console.WriteLine(pairs);
                }
            }
        }
        static double [] Sum12(int Count)
        {
            double [] resultArray = new double[Count];
            Random r = new Random();
            for (int j = 0; j < Count; j++)
            {
                double result = 0;
                for(int i = 0; i<12; i++)
                {
                    result = result + r.NextDouble();
                }
                result = result /6.0;
                resultArray[j] = result;
            }
            return resultArray;
        }
        static double [ , ] BoxMuller(int Count)
        {
            double[ , ] Boxresult = new double[Count,2];
            Random r2_1 = new Random();
            Random r2_2 = new Random();
            for (int j = 0; j < Count; j++)
            {
                double x1 = r2_1.NextDouble();
                double x2 = r2_2.NextDouble();
                double z1 = Math.Sqrt(-2*Math.Log(x1))*Math.Cos(2*Math.PI*(x2));
                double z2 = Math.Sqrt(-2*Math.Log(x1))*Math.Sin(2*Math.PI*(x2));
                Boxresult[j,0] = z1;
                Boxresult[j,1] = z2;
            }
            return Boxresult;
        }
        static double [] Polar(int Count)
        {
            List <double> Polarresult = new List<double>();

            Random r3_1 = new Random();
            Random r3_2 = new Random();
            int Counter = Count;

            while(Counter > 0)
            {   
                double x1 = r3_1.NextDouble();
                double x2 = r3_2.NextDouble();
                if ((x1 * x1 + x2 * x2) <= 1 )
                {
                    Counter --; //counter-1=counter
                    double w = x1 * x1 + x2 * x2;
                    double c = Math.Sqrt(-2*Math.Log(w)/w);
                    double z1 = c*x1;
                    double z2 = c*x2;
                    Polarresult.Add(z1);
                
                }
            }
            double[] PolorNorm = Polarresult.ToArray();
            return PolorNorm;
        }

        static double [,] CorrGaussianways(int Count, double corr)
        {
            double [,] CorrArray = new double[Count, 2];

            Random r4_1 = new Random();
            Random r4_2 = new Random();

//           if (corr >= -1 && corr <= 1)
//            {
            for(int i = 0; i < Count; i++)
            {
                double e1 = r4_1.NextDouble();
                double e2 = r4_2.NextDouble();
                double z1 = e1;
                double z2 = corr * e1 + Math.Sqrt(1 - corr * corr) * e2;
                CorrArray[i,0] = z1;
                CorrArray[i,1] = z2;
            }

            return CorrArray;
        }

    }
}
// Corlaborate with Hu Hong