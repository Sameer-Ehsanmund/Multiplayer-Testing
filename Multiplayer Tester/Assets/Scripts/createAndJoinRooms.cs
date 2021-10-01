using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;
using TMPro;

public class createAndJoinRooms : MonoBehaviourPunCallbacks
{

    public InputField createInput;
    public InputField joinInput;
    public InputField usernameInput;

    public GameObject joiningFailedText;
    public GameObject startButton;
    public GameObject usernamePanel;
    public GameObject createJoinPanel;

    public void createRoom()
    {

        PhotonNetwork.CreateRoom(createInput.text, new RoomOptions() { MaxPlayers = 5 }, null);
    }

    public void joinRoom()
    {

        RoomOptions roomoptions = new RoomOptions();
        roomoptions.MaxPlayers = 5;
        PhotonNetwork.JoinOrCreateRoom(joinInput.text, roomoptions, TypedLobby.Default);
    }

    public override void OnJoinedRoom()
    {

        PhotonNetwork.LoadLevel("Game");
    }

    public override void OnJoinRoomFailed(short returnCode, string message)
    {

        joiningFailedText.SetActive(true);
    }

    public void settingUsername()
    {

        if (usernameInput.text.Length >= 3)
        {

            startButton.SetActive(true);
        }
        else
        {

            startButton.SetActive(false);
        }
    }

    public void onStart()
    {

        usernamePanel.SetActive(false);
        createJoinPanel.SetActive(true);
        PhotonNetwork.NickName = usernameInput.text;
    }
}
