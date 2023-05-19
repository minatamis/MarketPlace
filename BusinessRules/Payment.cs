namespace BusinessRules
{
    public class Payment
    {
        static void choosePaymentMethod(int choice)
        {
            //payment methods
            //1. gcash
            //2. cod

            if (choice == 1)
            {
                Console.Write("Enter your gcash number: ");
                int mobileNumber = Convert.ToInt32(Console.ReadLine());

                if(numberCountChecker(mobileNumber,11))
                {
                    Console.Write("Enter your 4 digit MPIN: ");
                    int pin = Convert.ToInt32(Console.ReadLine());

                    if (numberCountChecker(pin, 4))
                    {
                        Console.Write("Price charged to your gcash!");

                    }
                    else
                    {
                        Console.WriteLine("Wrong input!");
                    }
                }

            }
            else if (choice == 2)
            {
                DeliveryInfo.askDeliveryInfo();
                Console.WriteLine("Please prepare you payment upon delivery!");

            }
            else
            {
                Console.WriteLine("Invalid Choice!");

            }

        }
        static bool numberCountChecker(int number, int count)
        {
            char[] mobileArr = number.ToString().ToCharArray();

            if (mobileArr.Count() != count)
            {
                return false;
            }
            return true;

        }

    }

}