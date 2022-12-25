using TMPro;
using UnityEngine;
using System.IO;
using System.Net;
using Magnimus;
//using PlayFab;
//using PlayFab.ClientModels;
//using System;
//using UnityEngine.UI;
//using UnityEngine.SceneManagement;
//using UnityEngine.Networking;

public class PanelHandler:MonoBehaviour
    {
        //delegates
        //delegate void PanelSwitch();
        //PanelSwitch loginPanelActive;
        //PanelSwitch registrationPanelActive;
        //PanelSwitch otpPanelActive;

        [Header("Registration Input Fields")]
        [SerializeField] TMP_InputField emailAddress;
        [SerializeField] TMP_InputField nickname;
        [SerializeField] TMP_InputField registerPassword;
        [SerializeField] TMP_InputField confirmPassword;

        [SerializeField] TextMeshProUGUI errorMessage;


        [Header("Panels")]
        [SerializeField] public GameObject loginPanel;
        [SerializeField] public GameObject registrationPanel;
        [SerializeField] public GameObject otpPanel;
        [SerializeField] public GameObject errorPanel;

        [SerializeField] LoginRegisterButton loginRegisterButton;


        private void Start()
        {
            LoginPanelActivate();
        }
        public void OnRegisterButtonClicked()
        {
            RegisterPanelActivate();
        }
        public void ConfirmRegistrationClicked()
        {
            if(emailAddress.text == "" || nickname.text == "" || registerPassword.text == "" || confirmPassword.text == "" )
            {
                Debug.Log("Please fill all the fields");
                ThrowError("Please fill all the fields");
                return;
            }
            if (registerPassword.text != confirmPassword.text)
            {
                Debug.Log("Passwords do not Match.");
                ThrowError("Passwords don't match");
                return;
            }
            OtpPanelActivate();
        }
        public void ConfirmOtpClicked()
        {
            if (MagnimusAPI.otp == loginRegisterButton.returnOtp())
            {
                Debug.Log("Otp is working");
                loginRegisterButton.RegisterUser(MagnimusAPI.otp);
            }
  
            else
                ThrowError("Otp mismatch");
        }

        public void ThrowError(string message)
        {
            ErrorPanelActive(true); 
            errorMessage.text = message;
        }

        void OtpPanelActivate()
        {
            otpPanel.SetActive(true);
            registrationPanel.SetActive(false);
            loginPanel.SetActive(false);
            errorPanel.SetActive(false);
            loginRegisterButton.SendOtp();
        }
    
        void RegisterPanelActivate()
        {
            otpPanel.SetActive(false);
            registrationPanel.SetActive(true);
            loginPanel.SetActive(false);
            errorPanel.SetActive(false);
        }
        public void LoginPanelActivate()
        {
            otpPanel.SetActive(false);
            registrationPanel.SetActive(false);
            loginPanel.SetActive(true);
            errorPanel.SetActive(false);
        }
        public void ErrorPanelActive(bool isActive = false)
        {
            errorPanel.SetActive(isActive);
        }
        public void OnCancelRegisterButtonClicked()
        {
            // Reset all forms
            emailAddress.text = string.Empty;
            registerPassword.text = string.Empty;
            nickname.text = string.Empty;
            confirmPassword.text = string.Empty;

            // Show panels
            LoginPanelActivate();
        }

    }
    //public class Login : MonoBehaviour
    //{
    //    [SerializeField] TMP_InputField username;
    //    [SerializeField] TMP_InputField registerUsername;
    //    [SerializeField] TMP_InputField registerPassword;
    //    [SerializeField] TMP_InputField nickname;
    //    [SerializeField] TMP_InputField password;
    //    [SerializeField] TMP_InputField confirmPassword;
    //    public bool ClearPlayerPrefs;
    //    [SerializeField] TMP_InputField codeText;
    //    [SerializeField] TMP_Text errorText;
    //    [SerializeField] private string displayname;
    //    [SerializeField] public string emailID;
    //    [SerializeField] private bool registerFlag = false;
    //    private int code;
    //    [SerializeField] Toggle rememberMe;

    //    [SerializeField] GameObject loginStackPanel;
    //    [SerializeField] GameObject signningPanel;
    //    [SerializeField] GameObject registerPanel;
    //    [SerializeField] GameObject errorPannel;
    //    [SerializeField] GameObject loadingScreen;
    //    [SerializeField] GameObject verificationPannel;

    //    public static Action<string> OnSceneLoad = delegate { };

    //    // Settings for what data to get from playfab on login.
    //    public GetPlayerCombinedInfoRequestParams InfoRequestParams;

    //    // Reference to our Authentication service
    //    private PlayFabAuthService _AuthService = PlayFabAuthService.Instance;

    //    public void Awake()
    //    {
    //        if (ClearPlayerPrefs)
    //        {
    //            Debug.Log("Awake");
    //            _AuthService.UnlinkSilentAuth();
    //            _AuthService.ClearRememberMe();
    //            _AuthService.AuthType = Authtypes.None;
    //        }

    //        //Set our remember me button to our remembered state.
    //        rememberMe.isOn = _AuthService.RememberMe;

    //        //Subscribe to our Remember Me toggle
    //        rememberMe.onValueChanged.AddListener(
    //            (toggle) =>
    //            {
    //                _AuthService.RememberMe = toggle;
    //            });
    //    }

    //    private void Start()
    //    {
    //        //loginStackPanel.SetActive(false);
    //        //signningPanel.SetActive(false);
    //        //registerPanel.SetActive(false);

    //        PlayFabAuthService.OnDisplayAuthentication += HandleOnDisplayAuthentication;
    //        PlayFabAuthService.OnLoginSucess += HandleOnLoginSucces;
    //        PlayFabAuthService.OnPlayFabError += HandleOnLoginError;
    //        // Set the data we want at login from what we chose in our meta data.
    //        _AuthService.InfoRequestParams = InfoRequestParams;

    //        // Start the authentication process.
    //        Debug.Log(_AuthService.AuthType);
    //        _AuthService.Authenticate();
    //    }

    //    private void HandleOnLoginError(PlayFabError error)
    //    {
    //        switch (error.Error)
    //        {
    //            case PlayFabErrorCode.InvalidEmailAddress:
    //            case PlayFabErrorCode.InvalidPassword:
    //            case PlayFabErrorCode.InvalidEmailOrPassword:
    //                //StatusText.text = "Invalid Email or Password";
    //                loadingScreen.SetActive(false);
    //                errorPannel.SetActive(true);
    //                errorText.text = "Invalid Email or Password";
    //                break;
    //            case PlayFabErrorCode.AccountNotFound:
    //                //registerPanel.SetActive(true);
    //                //signningPanel.SetActive(false);
    //                loadingScreen.SetActive(false);
    //                errorPannel.SetActive(true);
    //                errorText.text = "Account is not Registered !!";
    //                return;
    //            case PlayFabErrorCode.InvalidParams:
    //                errorPannel.SetActive(true);
    //                loadingScreen.SetActive(false);
    //                errorText.text = "password should be six character long or invalid emaild -Id";
    //                break;
    //            case PlayFabErrorCode.UsernameNotAvailable:
    //                errorPannel.SetActive(true);
    //                loadingScreen.SetActive(false);
    //                errorText.text = "Username already taken !!";
    //                break;
    //            case PlayFabErrorCode.EmailAddressNotAvailable:
    //                errorPannel.SetActive(true);
    //                loadingScreen.SetActive(false);
    //                errorText.text = "Username already registered !!";
    //                break;
    //            default:
    //                Debug.Log(error.GenerateErrorReport());
    //                loadingScreen.SetActive(false);
    //                break;
    //        }

    //        //Also report to debug console, this is optional.
    //        Debug.Log(error.Error);
    //        Debug.LogError(error.GenerateErrorReport());

    //    }

    //    private void HandleOnLoginSucces(LoginResult result)
    //    {
    //        if (registerFlag)
    //        {
    //            Debug.LogFormat("Logged In as: {0}", result.PlayFabId);
    //            Debug.Log(registerUsername.text);
    //            PlayFabClientAPI.GetAccountInfo(new GetAccountInfoRequest { Email = registerUsername.text },
    //            result =>
    //            {
    //            //Handle AccountInfo
    //            Debug.Log(result.AccountInfo.PlayFabId);
    //                emailID = result.AccountInfo.Username;
    //                Debug.Log(emailID);
    //                UpdateDisplayName(emailID);
    //            },
    //            error => { Debug.LogError(error.GenerateErrorReport()); });
    //            SceneController.LoadScene("Magnimus_Register");
    //            //SceneManager.LoadScene("Magnimus_Register");
    //            //UpdateDisplayName(displayname);

    //        }
    //        else
    //        {

    //            Debug.LogFormat("Logged In as: {0}", result.PlayFabId);
    //            Debug.Log(username.text);
    //            PlayFabClientAPI.GetAccountInfo(new GetAccountInfoRequest { Email = username.text },
    //            result =>
    //            {
    //            //Handle AccountInfo
    //            Debug.Log(result.AccountInfo.PlayFabId);
    //                emailID = result.AccountInfo.Username;
    //                Debug.Log(emailID);
    //                UpdateDisplayName(emailID);
    //            },
    //            error => { Debug.LogError(error.GenerateErrorReport()); });
    //            SceneController.LoadScene("Magnimus_Register");
    //            //SceneManager.LoadScene("Magnimus_Register");
    //            //UpdateDisplayName(displayname);
    //        }
    //    }

    //    private void HandleOnDisplayAuthentication()
    //    {
    //        loginStackPanel.SetActive(true);

    //    }


    //    // UI Function

    //    public void SetUserName(string name)
    //    {
    //        username.text = name;
    //        PlayerPrefs.SetString("EMAIL-ID", name);
    //        Debug.Log(PlayerPrefs.GetString("EMAIL_ID"));
    //    }

    //    public void SetNickName(string nickName)
    //    {
    //        nickname.text = nickName;
    //        //PlayerPrefs.SetString("USERNAME", nickName);
    //    }
    //    //public void SetDisplayName(string displayName)
    //    //{
    //    //    displayname = displayName;
    //    //    Debug.Log(displayname.ToString());
    //    //}
    //    public void SetPassword(string passcode)
    //    {
    //        password.text = passcode;

    //    }
    //    public void OnLoginClicked()
    //    {
    //        if (string.IsNullOrEmpty(username.text))
    //        {
    //            errorPannel.SetActive(true);
    //            errorText.text = "Empty field !!";
    //            return;
    //        }

    //        if (string.IsNullOrEmpty(password.text))
    //        {
    //            errorPannel.SetActive(true);
    //            errorText.text = "Empty field !!";
    //            return;
    //        }
    //        _AuthService.email = username.text;
    //        _AuthService.username = nickname.text;
    //        _AuthService.password = password.text;
    //        _AuthService.Authenticate(Authtypes.EmailAndPassword);

    //        loadingScreen.SetActive(true);
    //        Debug.Log("login button clicked");
    //    }
    //    public void SetConfirmPassword(string confirmpasscode)
    //    {
    //        confirmPassword.text = confirmpasscode;
    //    }

    //    public void SetRegisterUsername(string registerUserName)
    //    {
    //        registerUsername.text = registerUserName;
    //    }

    //    public void SetRegisterPassword(string RegisterPasscode)
    //    {
    //        registerPassword.text = RegisterPasscode;
    //    }

    //    public void SetReceivedCode(string codeReceived)
    //    {
    //        codeText.text = codeReceived;
    //    }

    //    public void OnRegisterButtonClick()
    //    {
    //        registerPanel.SetActive(true);
    //        signningPanel.SetActive(false);
    //        registerFlag = true;
    //    }

    //    //magnimus api 
    //    public void verification()
    //    {
    //        registerPanel.SetActive(false);
    //        verificationPannel.SetActive(true);
    //        code = UnityEngine.Random.Range(1000, 5000);
    //        HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(string.Format("http://ashishsahani.com/build/magnimusBackend/sendCode.php/?email_id={0}&message={1}&nickname={2}", registerUsername.text, code, nickname.text));
    //        HttpWebResponse response = (HttpWebResponse)request.GetResponse();
    //        StreamReader reader = new StreamReader(response.GetResponseStream());
    //        string jsonResponse = reader.ReadToEnd();
    //        Debug.Log(jsonResponse);
    //        Debug.Log(code);
    //    }

    //    public void OnRegisterButtonClicked()
    //    {
    //        loadingScreen.SetActive(true);
    //        if (registerPassword.text != confirmPassword.text)
    //        //if (registerPassword.text != confirmPassword.text && code.ToString() != codeText.text)
    //        {
    //            Debug.Log("Passwords do not Match.");
    //            loadingScreen.SetActive(false);
    //            errorPannel.SetActive(true);
    //            errorText.text = "Passwords do not Match.";
    //            return;
    //        }

    //        //StatusText.text = string.Format("Registering User {0} ...", Username.text);

    //        _AuthService.email = registerUsername.text;
    //        _AuthService.username = nickname.text;
    //        _AuthService.password = registerPassword.text;
    //        _AuthService.Authenticate(Authtypes.RegisterPlayFabAccount);
    //        Debug.Log("registration button clicked");
    //    }


    //    public void OnCancelRegisterButtonClicked()
    //    {
    //        // Reset all forms
    //        username.text = string.Empty;
    //        password.text = string.Empty;
    //        nickname.text = string.Empty;
    //        confirmPassword.text = string.Empty;
    //        codeText.text = string.Empty;

    //        // Show panels
    //        registerPanel.SetActive(false);
    //        verificationPannel.SetActive(false);
    //        signningPanel.SetActive(true);
    //    }
    //    private void UpdateDisplayName(string displayname)
    //    {
    //        Debug.Log($"Updating Playfab account's Display name to: {displayname}"); 
    //        PlayerPrefs.SetString("USERNAME", displayname);
    //        Debug.Log(PlayerPrefs.GetString("USERNAME"));
    //        var request = new UpdateUserTitleDisplayNameRequest { DisplayName = displayname };
    //        PlayFabClientAPI.UpdateUserTitleDisplayName(request, OnDisplayNameSuccess, OnFailure);
    //    }
    //    private void OnDisplayNameSuccess(UpdateUserTitleDisplayNameResult result)
    //    {
    //        Debug.Log($" you have updated the display name of the playfab account");
    //        //SceneController.LoadScene("Register");
    //        //set scene
    //        //SceneManager.LoadScene("Register");
    //    }
    //    private void OnFailure(PlayFabError result)
    //    {
    //        Debug.Log(result);
    //    }
    //}
