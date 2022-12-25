
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

namespace Magnimus
{
    public class LoginRegisterButton : MonoBehaviour
    {
        [SerializeField] GameObject errorPanel;
        [SerializeField] TextMeshProUGUI userText;
        [SerializeField] TMP_InputField email;
        [SerializeField] TMP_InputField password;
        [SerializeField] PanelHandler panelHandler;

        //[Header("Register")]
        //[SerializeField] string rEmail; //"psynity@gmail.com"
        //[SerializeField] string rPassword; //"aditya"
        //[SerializeField] string rUsername; //registered username
        //[SerializeField] string rGenOtp; //generated otp
        //[SerializeField] string rEnteredOtp; //entered otp

        [Header("Serializable Register")]
        [SerializeField] TMP_InputField rEmail; //"psynity@gmail.com"
        [SerializeField] TMP_InputField rPassword; //"aditya"
        [SerializeField] TMP_InputField rUsername; //registered username
        [SerializeField] string rGenOtp; //generated otp
        [SerializeField] TMP_InputField rEnteredOtp; //entered otp
        //[SerializeField] PanelHandler panelHandler;
        // Start
        private void Start()
        {
            errorPanel.SetActive(false);
        }
        public void LoginUser()
        {
            //contains the login data

            JSONInputLogin loginData = new JSONInputLogin();
            //redefining the login data according to given email and password
            loginData.email_id = email.text;
            loginData.password = password.text;
            if(email.text == "" || password.text == "")
            {
                panelHandler.ThrowError("Fields can't be empty");
                return;
            }
            //converting the login data in form of json string
            string jsonLoginData = JsonUtility.ToJson(loginData);

            //JSON output for the respective email
            JSONLoginOutput user = Magnimus.MagnimusAPI.LoginUser(jsonLoginData);
            Debug.Log("It is working " + user.success);
            //userText.text = user.token;
        
            switch(user.success)
            {
                case "true":
                    {
                        //Debug.Log("A user exists");
                        OnLoginSuccess(loginData);
                    }

                    break;
                case "false":
                    {
                        //Debug.Log("A user doesn't exists");
                        OnFailedLogin(user);
                    }
                    break;
            }
        }

        public void RegisterUser(string otp)
        {
            //contains the  register data
            JSONRegisterInput registerData = new JSONRegisterInput();
            //redefining the register data according to given email and password
            registerData.email_id = rEmail.text;
            registerData.password = rPassword.text;
            registerData.username = rUsername.text;
            registerData.generatedOtp = otp;
            registerData.enteredOtp = rEnteredOtp.text;
            //Debug.Log(rEmail.text + " " + rPassword.text + " " + rUsername.text + " "+ rGenOtp + " "+ rEnteredOtp.text);
            //registerData.email_id = "ser@mag.com";
            //registerData.password = "123456";
            //registerData.username = "servo";
            //registerData.generatedOtp = "1234";
            //registerData.enteredOtp = "1234";

            //converting the login data in form of json string
            string jsonLoginData = JsonUtility.ToJson(registerData);

            //JSON output for the respective email
            JSONRegisterOutput user = Magnimus.MagnimusAPI.RegisterUser(jsonLoginData);
            Debug.Log("It is working register " + user.success);
            //userText.text = user.token;

            switch (user.success)
            {
                case "true":
                    {
                        //Debug.Log("A user exists");
                        OnRegisterSuccess(registerData);
                    }

                    break;
                case "false":
                    {
                        //Debug.Log("A user doesn't exists");
                        OnFailedRegister(user);
                    }
                    break;
            }
        }

        public int SendOtp()
        {
            JSONSendOtp otpData = new JSONSendOtp();
            otpData.email_id = rEmail.text;
            int otpGenerated = GenerateRandomOtp();
            otpData.generatedOtp = otpGenerated.ToString();
            MagnimusAPI.otp = otpData.generatedOtp;

            string jsonOtpData = JsonUtility.ToJson(otpData);

            JSONSendOtpOutput otpOutput = Magnimus.MagnimusAPI.GenerateOtp(jsonOtpData);
            return 0;

        }
        int GenerateRandomOtp()
        {
            int otp;
            otp = Random.Range(1000, 9999);
            return otp; 
        }
        void OnRegisterSuccess(JSONRegisterInput user)
        {
            Debug.Log("A user exists");
            SceneManager.LoadScene("OnlinePlayers");
            MagnimusAPI.userEmail = user.email_id;
        }
        void OnFailedRegister(JSONRegisterOutput user)
        {
            Debug.Log("A user doesn't exists");
            errorPanel.SetActive(true);
            errorPanel.transform.Find("ErrorMessage").GetComponent<TextMeshProUGUI>().text = user.message;
        }
        void OnLoginSuccess(JSONInputLogin user)
        {
            Debug.Log("A user exists");
            MagnimusAPI.userEmail = user.email_id;
            SceneManager.LoadScene("OnlinePlayers");
        }
        void OnFailedLogin(JSONLoginOutput user)
        {
            Debug.Log("A user doesn't exists");
            errorPanel.SetActive(true);
            errorPanel.transform.Find("ErrorMessage").GetComponent<TextMeshProUGUI>().text = user.message;
        }    
        public void GetAllUsers()
        {
            JSONUsers users = MagnimusAPI.GetAllUsers();
            //Debug.Log("Getting All users" + users.statusMessage);
            Debug.Log(users.user[0].Email_ID);

        }
        private void OnDisable()
        {
            errorPanel.SetActive(false);
        }
        public string returnOtp()
        {
            if (rEnteredOtp.text != null) return rEnteredOtp.text;
            return null;
        }


    }
}
