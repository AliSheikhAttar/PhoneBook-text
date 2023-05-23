public class  Name
{
    public string FirstName {get; private set;}
    public string LastName {get; private set;}
    public string FullName => $"{this.FirstName} , {this.LastName}"; 
    public Name(string first, string last)
    {
        this.FirstName = first;
        this.LastName = last;
    }

    
}