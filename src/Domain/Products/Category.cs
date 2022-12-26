using Flunt.Validations;

namespace IWantApp.Domain.Products;

public class Category : Entity
{
    public bool Active { get; set; }


	public Category(string name, string createdBy, string updatedBy)
    {

        Validate();

        Name = name;
        Active = true;
        CreatedBy = createdBy;
        CreatedOn = DateTime.Now;
        UpdatedBy = updatedBy;
        UpdatedOn = DateTime.Now;


    }
    private void Validate()
    {
        //Adicionamos um contrato para categoria, dizer que nome não pode ser nulo
        var contract = new Contract<Category>()
            .IsNotNullOrEmpty(Name, "Name", "O campo Nome é obrigatório")
            .IsGreaterOrEqualsThan(Name, 3, "Name", "O nome deve ter 3 ou mais caracteres")
            .IsNotNullOrEmpty(CreatedBy, "CreatedBy", "O campo CreatedBy é obrigatório")
            .IsNotNullOrEmpty(UpdatedBy, "UpdatedBy", "O campo UpdatedBy é obrigatório");
        AddNotifications(contract);
    }

    public void EditInfo(string name, bool active)
    {
        Validate();

        Name = name;
        Active = active;
        UpdatedBy = "Editado";
        UpdatedOn = DateTime.Now;


    }
}
