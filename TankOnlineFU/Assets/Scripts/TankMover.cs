using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System.Linq;
using DefaultNamespace;
using Entity;
using UnityEngine;

public class TankMover : MonoBehaviour
{
    // Start is called before the first frame update

    public float speed;

    Timer timePowerUp;
    Timer timeRokect;

    void Start()
    {
        timePowerUp = gameObject.AddComponent<Timer>();
        timeRokect = gameObject.AddComponent<Timer>();

        timePowerUp.Duration = 5;
        timeRokect.Duration = 5;
    }

    // Update is called once per frame
    void Update()
    {
        if (timePowerUp.Finished)
        {
            PowerUp(false);
        }

        if (timeRokect.Finished)
        {
            Rocket(true);
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
        Debug.Log(collision.name);
        switch (collision.name)
        {
            case "Gold":
            case "Gold(Clone)":
                Debug.Log("Gold");
                UpdateGold();
                Destroy(collision.gameObject);
                break;
            case "PowerUp":
            case "PowerUp(Clone)":
                Debug.Log("PowerUp");
                if (!timePowerUp.checkRunning())
                {
                    PowerUp(true);
                    timePowerUp.Run();
                }
                Destroy(collision.gameObject);
                break;
            case "Rocket":
            case "Rocket(Clone)":
                Debug.Log("Rocket");
                if (!timeRokect.checkRunning())
                {
                    Rocket(false);
                    timeRokect.Run();
                }
                Destroy(collision.gameObject);
                break;
            case "Shield":
            case "Shield(Clone)":
                Debug.Log("Shield");
                Destroy(collision.gameObject);
                break;
            default:
                break;
        }

        

    }

    private void UpdateGold()
    {
        //To do
        // gold = current gold + 1;
        int currentGold = 0;
        //try
        //{
        //    currentGold = int.Parse(GameObject.Find("GoldText").GetComponent<Text>().text);
        //}
        //catch (System.Exception)
        //{
        //    currentGold = 0;
        //}
        currentGold++;
        //to do
        GameObject.Find("GoldText").GetComponent<Text>().text = currentGold.ToString();
    }

    private void PowerUp(bool type)
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


    private void Rocket(bool type)
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

}