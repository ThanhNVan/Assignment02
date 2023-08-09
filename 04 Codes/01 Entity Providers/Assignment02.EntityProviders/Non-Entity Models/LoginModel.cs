namespace Assignment02.EntityProviders;

public class LoginModel
{
	#region [ Properties ]
	public string Email { get; set; }
	public string Password { get; set; }
	#endregion

	#region [ CTor ]
	public LoginModel(string email, string password) {
		this.Email = email;
		this.Password = password;	
	}
	#endregion

	#region [ CTor ]
	public LoginModel() {

	}
	#endregion
}
