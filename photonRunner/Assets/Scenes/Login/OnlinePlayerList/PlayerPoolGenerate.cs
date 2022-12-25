using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
//using Unity.UIElements;
using UnityEngine.UI;

namespace Magnimus
{
    public class PlayerPoolGenerate : MonoBehaviour
    {
        //the object that needs to be instantiated
        [SerializeField]GameObject playerStatPref;
        //stores the list of players that are taken from GetAllUsers Url
        
        void Start()
        {
            
            TraversePlayersPool();
        }

        public void TraversePlayersPool()
        {

            List<user> userInfoList = new List<user>();
            JSONUsers playersInfo = MagnimusAPI.GetAllUsers();
            userInfoList = playersInfo.user;

            //deleting the previously built game object
            foreach(Transform obj in transform)
            {
                Destroy(obj.gameObject);
            }
            foreach (user player in userInfoList)
            {
                //we only generate players which is not the user
                if(player.Email_ID != MagnimusAPI.userEmail)
                {
                    GeneratePlayer(player);
                }
            }
        }

        private void GeneratePlayer(user player)
        {
            GameObject tempPlayerStat = Instantiate(playerStatPref, transform.position, Quaternion.identity);
            //takes the first object that has TMP Attached i.e. name
            TextMeshProUGUI tempTextComponent = tempPlayerStat.GetComponentInChildren<TextMeshProUGUI>();
            //change the color of the dot for the player

            //tempPlayerStat.GetComponentInChildren<>
            tempPlayerStat.transform.Find("OnlineStat").gameObject.GetComponent<Image>().color = CheckOnline(player);
            //change the text to nickname of the player
            tempTextComponent.text = player.NickName;
            tempPlayerStat.transform.parent = this.transform;
        }

        //returns green color if player is online
        Color CheckOnline(user player)
        {
            if (player.Login_State == 1)
            {
                Color green = new Color(0, 255, 0, 0.8f);
                return green;
            }
            return Color.red;

        }
        // Update is called once per frame
        void Update()
        {
            

        }
    }
}
