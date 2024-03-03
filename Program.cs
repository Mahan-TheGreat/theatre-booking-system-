using System;

namespace C0902945_TakeHome
{
    internal class Program
    {
        /* global for all functions */
        public static int currentBookingNumber = 1;

        //Reserves Seats with Front or Back Preference
        static void reserveSeats(int[,] theatreArray, int numberOfSeats, int preference)
        {
            int availTogether = 0;
            int row = 7;
            int col = 0;
            /* sit at the back */
            if (preference == 1)
            {
                for (row = 7; row >= 0; row--)
                {
                    for (col = 9; col >= 0; col--)
                    {
                        /* if seat is set to 0, it is empty */
                        if (theatreArray[row, col] == 0)
                        {
                            availTogether++;
                        }
                        else //if seat is booked you need to restart
                        {
                            availTogether = 0;
                        }

                        if (availTogether == numberOfSeats)
                        {
                            break;
                        }
                    }

                    /* you have enough seats to book */
                    if (availTogether == numberOfSeats)
                    {
                        break;
                    }
                    else
                    {
                        availTogether = 0;
                    }

                }

                int stop = col + (numberOfSeats - 1);
                if (availTogether == numberOfSeats)
                {
                    for (int x = col; x <= stop; x++)
                    {
                        theatreArray[row, x] = currentBookingNumber;
                    }
                    currentBookingNumber += 1;
                    Console.WriteLine("Reservations made for " + numberOfSeats + " seats.\n ");

                }
                else /* no n seats together anywhere in the theatre, cannot complete booking */
                {
                    Console.WriteLine("Sorry! " + numberOfSeats + " seats are not available. Reservation could not be made.\n");

                }
            }
            else if(preference == 2)/* sit at front */
            {
                for (row = 0; row <= 7; row++)
                {
                    for (col = 0; col <= 9; col++)
                    {
                        /* if seat is set to 0, it is empty */
                        if (theatreArray[row, col] == 0)
                        {
                            availTogether++;
                        }
                        else //if seat is booked you need to restart
                        {
                            availTogether = 0;
                        }

                        if (availTogether == numberOfSeats)
                        {
                            break;
                        }
                    }

                    /* you have enough seats to book */
                    if (availTogether == numberOfSeats)
                    {
                        break;
                    }
                    else
                    {
                        availTogether = 0;
                    }

                }

                int stop = col - (numberOfSeats - 1);
                if (availTogether == numberOfSeats)
                {
                    for (int x = col; x >= stop; x--)
                    {
                        theatreArray[row, x] = currentBookingNumber;
                    }
                    currentBookingNumber += 1;
                    Console.WriteLine("Reservations made for " + numberOfSeats + " seats.\n ");

                }
                else /* no n seats together anywhere in the theatre, cannot complete booking */
                {
                    Console.WriteLine("Sorry! " + numberOfSeats + " seats are not available. Reservation could not be made.\n ");
                }
            }
            else
            {
                Console.WriteLine("Error! Enter a valid preference (1 or 2)!\n");
            }

            return;
        }

        //Reserves Seats on Desired Row and Column
        static void reserveSeats(int[,] theatreArray, int numberOfSeats, int row, int columnStart)
        {
            int availTogether = 0;
            int col = columnStart;

           for (col = columnStart-1; col < 10; col++)
                {
                  /* if seat is set to 0, it is empty */
                  if (theatreArray[row-1, col] == 0)
                    {
                        availTogether++;
                    }
                  else //if seat is booked you need to restart
                    {
                        availTogether = 0;
                    }
                   /* you have enough seats to book */
                  if (availTogether == numberOfSeats)
                    {
                        break;
                    }
            
                }

            if (availTogether == numberOfSeats)
            {
                int stop = col - (numberOfSeats - 1);
                for (int x = col; x >= stop; x--)
                {
                    theatreArray[row-1, x] = currentBookingNumber;
                }
                Console.WriteLine("Reservations made for " + numberOfSeats + " seats.\n ");

                currentBookingNumber += 1;
            }
            else /* no n seats together anywhere in the theatre, cannot complete booking */
            {
                Console.WriteLine("***********");
                Console.WriteLine("Sorry! " + numberOfSeats + " seats are not available strating on " + columnStart + " column on row "+ row + " . Reservation could not be made");

            }
        }

        //Cancel Reservations by Reservation Number
        static void cancelSeats(int[,] theatreArray, int bookingNumber)
        {
            int seatCancelled = 0;
            for (int row = 0; row <= 7; row++)
            {
                for (int col = 0; col <= 9; col++)
                {
                    /* Clear booking if booking number matched */
                    if (theatreArray[row, col] == bookingNumber)
                    {
                        theatreArray[row, col] = 0;
                        seatCancelled += 1;
                    }
                 
                }

            }
            if(seatCancelled == 0)
            {
                Console.WriteLine("No booking with number " + bookingNumber + " found.");
            }
            else
            {
                Console.WriteLine( "" + seatCancelled + " seats cancelled with booking number: " + bookingNumber);

            }

        }

        //Remove empty seats if any
        static void removeEmptySeats(int[,] theatreArray, int row)
        {
            //TODO
            int count = 0;
            int row1 = row - 1;

            for (int col = 0; col < 10; col++)
            {         /* if seat is set to 0, it is empty */
                if (theatreArray[row1, col] == 0)
                {
                    count++;
                    for (int x = col; x < 10; x++)
                    {
                        if (theatreArray[row1,x] != 0)
                        {
                            theatreArray[row1,col] = theatreArray[row1,x];
                            theatreArray[row1, x] = 0;

                            Console.WriteLine("Person from seat " + (x + 1 ) + " moved to seat " + (col + 1) + ".");
                            break;
                        }
                    }

                }
            }


        }

        //Search for Reservations by Reservation Number
        static void search(int[,] theatreArray, int bookingNumber)
        {
            bool bookingFound = false;
            for (int row = 0; row <= 7; row++)
            {
                for (int col = 0; col <= 9; col++)
                {
                    /* Clear booking if booking number matched */
                    if (theatreArray[row, col] == bookingNumber)
                    {
                        Console.WriteLine("Booking found at row :" + (row + 1) + ", column :" + (col + 1) + " .\n");
                        bookingFound = true;
                    }
                }
            }
            if (bookingFound == false)
            {
                Console.WriteLine("No booking with number " + bookingNumber + " found.\n");
            }
        }

        //Returns total reservations made
        static int totalBooked(int[,] theatreArray)
        {
            int totalBooked = 0;
            for (int row = 7; row >= 0; row--)
            {
                for (int col = 0; col < 10; col++)
                {
                    if (theatreArray[row, col] != 0)
                    {
                        totalBooked++;
                    }
                }
            }
            return totalBooked;
        }

        //Prints Map of the Theatre
        static void displayMap(int[,] theatreArray)
        {
            for (int row = 7; row >= 0; row--)
            {
                for (int col = 0; col < 10; col++)
                {
                    Console.Write(theatreArray[row, col] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine("");

        }

        //Prints Main Menu on Console
        static void displayMenu()
        {
            Console.WriteLine("***************Menu***************\n");

            Console.WriteLine("1. Reserve seats");
            Console.WriteLine("2. Reserve seats with specific starting row and column");
            Console.WriteLine("3. Cancel reservation");
            Console.WriteLine("4. Remove empty seats from specific row");
            Console.WriteLine("5. Search for reservation");
            Console.WriteLine("6. Total seats booked");
            Console.WriteLine("7. Display theatre map");
            Console.WriteLine("8. Exit Application\n");

            Console.WriteLine("**********************************\n");


        }

        
        //Menu one of the Main Menu
        private static void MenuOne(int[,] theatreArray)
        {
            Console.WriteLine("Enter number of adjacent seats you require: ");
            try
            {
                int numberOfSeats = int.Parse(Console.ReadLine());
                Console.WriteLine("Preference of seatin (1 for back, 2 for front): ");
                int preference = int.Parse(Console.ReadLine());
                reserveSeats(theatreArray, numberOfSeats, preference);

            }
            catch (Exception e)
            {
                Console.WriteLine("Enter a valid number!");
            }
        }

        //Menu two of the Main Menu
        private static void MenuTwo(int[,] theatreArray)
        {
            Console.WriteLine("Enter number of adjacent seats you require: ");
            try
            {
                int numberOfSeats2 = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter row number you wish to book seats: ");
                int startingRow = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter column/seat number you want your seats to begin at: ");
                int startingColumn = int.Parse(Console.ReadLine());
                reserveSeats(theatreArray, numberOfSeats2, startingRow, startingColumn);

            }
            catch (Exception e)
            {
                Console.WriteLine("Enter a valid number!");
            }
        }

        //Menu three of the Main Menu
        private static void MenuThree(int[,] theatreArray)
        {
            Console.WriteLine("Reservation number you would like to cancel: ");
            try
            {
                int cancellationNumber = int.Parse(Console.ReadLine());
                cancelSeats(theatreArray, cancellationNumber);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error! Enter a valid number!");
            }
        }

        //Menu four of the Main Menu
        private static void MenuFour(int[,] theatreArray)
        {
            Console.WriteLine("Which row would you like to remove empty seats from: ");
            try
            {
                int rowToRemoveSpace = int.Parse(Console.ReadLine());
                removeEmptySeats(theatreArray, rowToRemoveSpace);

            }
            catch (Exception e)
            {
                Console.WriteLine("Enter a valid number!");
            }
        }

        //Menu five of the Main Menu
        private static void MenuFive(int[,] theatreArray)
        {
            Console.WriteLine("Reservation number you are searching for: ");
            try
            {
                int reservationNumberToSearch = int.Parse(Console.ReadLine());
                search(theatreArray, reservationNumberToSearch);

            }
            catch (Exception e)
            {
                Console.WriteLine("Enter a valid number!");
            }
        }

        static void Main(string[] args)
        {
            int[,] theatreArray = new int[8, 10];
            int y = 0;

            while (y != 8)
            {
                displayMenu();

                try
                {
                    int x = int.Parse(Console.ReadLine());
                    Console.WriteLine("*****************");
                    Console.WriteLine("User Selection : " + x + "\n");

                    switch (x)
                    {
                        case 1:
                            MenuOne(theatreArray);
                            break;
                        case 2:
                            MenuTwo(theatreArray);
                            break;
                        case 3:
                            MenuThree(theatreArray);
                            break;
                        case 4:
                            MenuFour(theatreArray);
                            break;
                        case 5:
                            MenuFive(theatreArray);
                            break;
                        case 6:
                            int totalBook = totalBooked(theatreArray);
                            Console.WriteLine("The total number of seats reserved in the theatre is " + totalBook + ".\n");
                            break;
                        case 7:
                            Console.WriteLine("Displaying Theatre Map\n");
                            displayMap(theatreArray);
                            break;
                        case 8:
                            return;
                        default:
                            Console.WriteLine("Enter a valid value!");
                            break;

                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Enter a valid value.\n");

                }
            }


        }
    }

    }

