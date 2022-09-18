export class UserListDto {
    Id :number;
    Username:string;
    Address :string;
    Email :string;
    Mobile :string;
    BirthDate:string;
    ManagerId :number;
    typeId :number;
    Manager :string

    constructor(Id,
        Username,
        Address ,
        Email,
        Mobile,
        BirthDate,
        ManagerId ,
        typeId,
        Manager
    ){
        this.Id = Id;
        this.Username = Username;
        this.Address = Address;
        this.Email = Email;
        this.Mobile = Mobile;
        this.BirthDate = BirthDate;
        this.ManagerId = ManagerId;
        this.typeId = typeId;
        this.Manager = Manager;
    }
}
