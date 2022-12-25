using System.Collections.Generic;
using UnityEngine.Networking;
using System.Collections;
using UnityEngine;


[System.Serializable]
public class user
{
    public string Email_ID;
    public string NickName;
    public int Login_State;
}
[System.Serializable]
public class JSONUsers
{
    public string success;
    public string statusCode;
    public string statusMessage;
    public string message;

    public List<user> user;

}

