public class address
{
    public string State {get; private set;}
    public string Town {get; private set;}
    public string Street {get; private set;}
    public string Fulladdress => $"{this.State} , {this.Town} , {this.Street}"; 
    public address(string state, string town, string street)
    {
        this.State = state;
        this.Town = town;
        this.Street = street;
    }

}