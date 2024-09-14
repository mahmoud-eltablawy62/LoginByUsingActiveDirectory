using Microsoft.AspNetCore.Authentication;
using System.DirectoryServices.AccountManagement;

namespace LoginForm
{
    public class ActiveDirectoryHelper
    {
        // Method to get user details from Active Directory
        public static UserPrincipal GetUserDetails(string username)
        {
            // Create a PrincipalContext to connect to the domain
            using (var context = new PrincipalContext(ContextType.Domain, "RSADF.Com"))
            {
                // Find the user in the domain
                var userPrincipal = UserPrincipal.FindByIdentity(context, username);
                return userPrincipal;
            }
        }
        public static void PrintUserDetails(string username)
        {
            var user = GetUserDetails(username);
            if (user != null)
            {
                
                System.Diagnostics.Debug.WriteLine("Full Name: " + user.DisplayName);
                System.Diagnostics.Debug.WriteLine("Email: " + user.EmailAddress);
                System.Diagnostics.Debug.WriteLine("Phone Number: " + user.VoiceTelephoneNumber);
            }
            else
            {
                System.Diagnostics.Debug.WriteLine("User not found.");
            }
        }

        

    }
}
