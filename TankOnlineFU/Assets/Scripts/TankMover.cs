using System;
using UnityEngine.UI;
using System.Linq;
using DefaultNamespace;
using Entity;
using UnityEngine;

public class TankMover : MonoBehaviour
{
    public float speed;

    Timer timePowerUp;
    Timer timeRokect;
    Timer timeShield;

    public Health health;

    int currentGold;

    public GameObject shield_2;

    public AudioSource speedSound;
    public AudioSource shieldSound;

    void Start()
    {
        timePowerUp = gameObject.AddComponent<Timer>();
        timeRokect = gameObject.AddComponent<Timer>();
        timeShield = gameObject.AddComponent<Timer>();

        timePowerUp.Duration = 5;
        timeRokect.Duration = 5;
        timeShield.Duration = 5;

        currentGold = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (timePowerUp.Finished)
        {
            SetPowerUp(false);
        }

        if (timeRokect.Finished)
        {
            SetRocket(true);
        }

        if (timeShield.Finished)
        {
            SetShield(false);
        }
    }


    public Vector3 Move(Direction direction)
    {
        var currentPos = gameObject.transform.position;
        switch (direction)
        {
            case Direction.Down:
                currentPos.y -= speed * Time.deltaTime;
                break;
            case Direction.Left:
                currentPos.x -= speed * Time.deltaTime;
                break;
            case Direction.Right:
                currentPos.x += speed * Time.deltaTime;
                break;
            case Direction.Up:
                currentPos.y += speed * Time.deltaTime;
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(direction), direction, null);
        }

        gameObject.transform.position = currentPos;
        return currentPos;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log(collision.name);
        switch (collision.name)
        {
            case "GoldItem":
            case "GoldItem(Clone)":
                //Debug.Log("Gold");
                UpdateGold();
                Destroy(collision.gameObject);
                break;
            case "PowerUpItem":
            case "PowerUpItem(Clone)":
                //Debug.Log("PowerUp");
                if (!timePowerUp.checkRunning())
                {
                    speedSound?.Play(); // Play sound
                    SetPowerUp(true);
                    timePowerUp.Run();
                }
                else
                {
                    timePowerUp.SetElapsedSeconds(timePowerUp.GetElapsedSeconds() + 5);
                }
                Destroy(collision.gameObject);
                break;
            case "RocketItem":
            case "RocketItem(Clone)":
                //Debug.Log("Rocket");
                if (!timeRokect.checkRunning())
                {
                    SetRocket(false);
                    timeRokect.Run();
                }
                else
                {
                    timeRokect.SetElapsedSeconds(timeRokect.GetElapsedSeconds() + 5);
                }
                Destroy(collision.gameObject);
                break;
            case "ShieldItem":
            case "ShieldItem(Clone)":
                //Debug.Log("Shield");
                if (!timeShield.checkRunning())
                {
                    shieldSound?.Play();    // Play sound
                    SetShield(true);
                    timeShield.Run();
                }
                else
                {
                    timeShield.SetElapsedSeconds(timeShield.GetElapsedSeconds() + 5);
                }
                Destroy(collision.gameObject);
                break;
            default:
                break;
        }

        

    }

    private void UpdateGold()
    {
        currentGold++;
        //to do
        GameObject.Find("GoldText").GetComponent<Text>().text = currentGold.ToString();
    }

    private void SetPowerUp(bool type)
    {
        //To do
        // Update x2 dame;
        float currentSpeedTank = GameObject.FindWithTag("Player").GetComponent<TankMover>().speed;
        int currentSpeedFirer = GameObject.FindWithTag("Player").GetComponent<TankFirer>().speed;
        if (type)
        {
            GameObject.FindWithTag("Player").GetComponent<TankMover>().speed = currentSpeedTank * 2;
            GameObject.FindWithTag("Player").GetComponent<TankFirer>().speed = currentSpeedFirer * 3;
        }
        else
        {
            GameObject.FindWithTag("Player").GetComponent<TankMover>().speed = currentSpeedTank / 2;
            GameObject.FindWithTag("Player").GetComponent<TankFirer>().speed = currentSpeedFirer / 3;

            timePowerUp.Stop();
        }
    }


    private void SetRocket(bool type)
    {
        //To do
        // b?n xuyên ??a hình;
        GameObject.FindGameObjectsWithTag("BrickCell").ToList().ForEach(x => x.GetComponent<WallBrickController>().isEffect = type);
        GameObject.FindGameObjectsWithTag("StoneCell").ToList().ForEach(x => x.GetComponent<WallSteelController>().isEffect = type);

        if (type)
        {
            timePowerUp.Stop();
        }

    }

    private void SetShield(bool type)
    {
        health.hasShield = type;
        shield_2.SetActive(type);

        if (!type)
        {
            timeShield.Stop();
        }
    }

}