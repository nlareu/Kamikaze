using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AppController : MonoBehaviour {

    public GameObject GameOverPanel;
    public Text FinalPointsText;
    public GameObject CurrentPointsPanel;
    public Text CurrentPointsText;
    public PlayerController PlayerSource;
    public int PlayersCount = 1;
    public List<GameObject> RespawnPositions = new List<GameObject>();

    private List<PlayerController> players = new List<PlayerController>();
    private List<PlayerController> playersDead = new List<PlayerController>();


    // Use this for initialization
    void Start () {
        //for (int i = 0; i < this.PlayersCount; i++)
        //{
        //PlayerController player = Instantiate(this.PlayerSource, this.RespawnPositions[0].transform.position, Quaternion.identity);

        PlayerController player = this.PlayerSource;

        player.AppController = this;
        player.Died += this.Player_Died;
        player.HitEnemy += this.Player_HitEnemy;

        this.players.Add(player);
        //}
    }

    // Update is called once per frame
    void Update () {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            //Reset static.
            this.players.Clear();

            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }


    public int AddPlayer(PlayerController avatar)
    {
        this.players.Add(avatar);

        return this.players.Count;
    }
    private bool CheckRoundEnded()
    {
        return (this.players.Count - this.playersDead.Count <= 1);
    }
    public List<PlayerController> GetPlayers()
    {
        //Return a copy to prevent reference and not desired changes on the list.
        return new List<PlayerController>(this.players);
    }
    private void RestartRound()
    {
        this.playersDead.Clear();

        //for (int i = 0; i < this.players.Count; i++)
        //{
        //    var player = this.players[i];
        //    var respawnPos = this.RespawnPositions[i].transform.position;

        //    player.transform.position = new Vector2(respawnPos.x, respawnPos.y);

        //    player.gameObject.SetActive(true);
        //}
    }
    private void UpdatePlayerHealthStatus()
    {
        var player = this.PlayerSource;

        this.CurrentPointsText.text = player.Health.ToString();
    }


    private void Player_Died(object sender, EventArgs e)
    {
        this.CurrentPointsPanel.gameObject.SetActive(false);

        this.FinalPointsText.text += this.PlayerSource.Health.ToString();

        this.GameOverPanel.SetActive(true);
    }
    private void Player_HitEnemy(object sender, EventArgs e)
    {
        this.UpdatePlayerHealthStatus();
    }
}
