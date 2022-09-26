// cerner_2tothe5th_2022
// cerner_2^5_2022
class HelloGroovy {
    static void main(String[] args) {
        println("Hello, Groovy\n");
        def aNumber = 3;
        println("Factorial of " + aNumber + " is " + factorial(aNumber));
    }
    
    static int factorial(int no) {
        return no==1?1:(no *factorial(no-1));
    }
}
