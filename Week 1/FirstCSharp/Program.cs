// See https://aka.ms/new-console-template for more information
// Console.WriteLine("Hello, World!");

// int height = 79;

// if(height >= 42 && height <= 78)
// {
//     Console.WriteLine("Get on that coaster!");
// }else {
//     Console.WriteLine("Get Away!");
// }

// bool order = true;
// if(order == true){
//     Console.WriteLine("Order complete!");
// } else{
//     Console.WriteLine("Order still processing");
// }

// for(int i=0; i<50; i++){
//     if(i % 2 == 0){
//         Console.WriteLine(i);
//     }
// }

// for(int i=99; i<0; i=(i-3)){
//     if(i % 3 == 0){
//         Console.WriteLine(i);
//     }
// }

Random rand = new Random();
for(int i = 1; i <= 10; i++)
{
    // Every time the loop executes we will get a NEW random value between 2 and 7
    Console.WriteLine(rand.Next(2,99999));
}