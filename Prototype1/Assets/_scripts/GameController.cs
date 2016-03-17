using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


[System.Serializable]
public enum GameState
{
    Start,
    TriggerOne,
    TriggerTwo,
    TriggerThree,
    TriggerFour,
    TriggerFive,
    TriggerSix,
    TriggerSeven,
    TriggerEight,
    TriggerNine,
    TriggerTen,
    TriggerEleven,
    TriggerTwelve,
    TriggerThirteen,
    TriggerFourteen,
    TriggerFifteen,
    TriggerSixteen,
    Restart,
    None
};

[System.Serializable]
public enum PlayerState
{
    Passive,
    Scared,
    Darkness
};

[System.Serializable]
public class GameControl
{

    public GameState myGameState = GameState.None;
    public PlayerState myPlayerState = PlayerState.Passive;


    // increases the stat with a given name by an ammount
    public void SetCurrentGameState(GameState _gState)
    {
        myGameState = _gState;
        ChangeGameState();
    }
    public void SetCurrentPlayerState(PlayerState _pState)
    {
        myPlayerState = _pState;
        ChangePlayerStates();
    }

    public void ChangeGameState()
    {
        switch (myGameState)
        {
            case GameState.None:

                //so far do nothing

                break;
            case GameState.Start:

                //study lights ON
                //door locked

                break;
            case GameState.TriggerOne:

                //Audio(Fax Machine)
                //Animation(Fax Machine)
                //Activate GameObject(Fax Note(1))

                break;
            case GameState.TriggerTwo:

                //Activate GameObjects(Mail in study)
                //Audio(door open)
                //Animation(Open study door)

                //loungeroom lights ON
                //Kitchen lights ON
                //Upstairs lights OFF

                break;
            case GameState.TriggerThree:

                //Audio(door open)
                //Animation(open laundry door)

                //Laundry lights ON

                break;
            case GameState.TriggerFour:

                //Audio(Fax Machine)
                //Animation(Fax Machine)
                //Activate GameObject(Fax Note(2))

                break;
            case GameState.TriggerFive:

               //Audio(transition to scene two)
               //SceneManager.LoadScene("SceneTwo"); 

                break;
            case GameState.TriggerSix:

                //Activate GameObject(Torch)

                break;
            case GameState.TriggerSeven:

                //Audio.Stop(radio)
                //Audio(door open)
                //Animation(open front door)

                break;
            case GameState.TriggerEight:

                //Audio(new atmosphere)
                //Activate GameObjects(Newspaper + Mail)

                break;
            case GameState.TriggerNine:

                //Audio(Fax Machine)
                //Animation(Fax Machine)
                //Activate GameObject(Fax Note(3))

                break;
            case GameState.TriggerTen:

                //Audio(portrait smash)
                //Activate GameObject(fallen portrait)

                break;
            case GameState.TriggerEleven:

                //Audio(upstairs noise)
                //Activate GameObject(Passport, Page from plants book)

                break;
            case GameState.TriggerTwelve:

                //lights ON in sisters room
                //Activate GameObjects(sisters toys)

                break;
            case GameState.TriggerThirteen:

                //Audio(Fax Machine)
                //Animation(Fax Machine)
                //Activate GameObject(Fax Note(4))

                break;
            case GameState.TriggerFourteen:

                //Audio(radio)
                //Activate GameObjects(Glass Cups with Poison)

                break;
            case GameState.TriggerFifteen:

                //Screen fade to black
                //Audio(Phone Ringing)
                //Screen fade in

                break;
            case GameState.TriggerSixteen:

                //Audio(000Call)
                //Screen fade to black
                //GameOver

                break;
            case GameState.Restart:

                //Audio(gameOver)
                //Screen fade to black
                //SceneManager.LoadScene(currentScene)

                break;
        }
        myGameState = GameState.None;
    }

    public void ChangePlayerStates()
    {

        switch (myPlayerState)
        {
            case PlayerState.Passive:


                break;
            case PlayerState.Scared:


                break;
            case PlayerState.Darkness:


                break;
        }
    }

    //will probably put this in seperate scripts
    public void SettingStates()
    {
        /*if ()
        {
            SetCurrentState(GameState.TriggerOne);
        }
        */
    }

};


//Pseudocode

/*  
SCENE ONE

    Start - inside study (door locked, lights on) //also make sure there is a portrait in hallway with only one sibling
    Player - tries to open door = trigger fax machine
    Fax Machine - activate note(1)
    PickUp & Read Note - open study door & activate study gameObjects (mail)

    lights on in lounge / lights off upstairs
    (if player tried to go upstairs = game restart)

    lounge room pick ups - books
    dinning room pick ups - cups
    kitchen pick ups - plants in window and book on plants on kitchen counter with riped out page

    if(mail, books, cups & poison have been picked up)
    {
        laundry door opens
    }

    if(pick up mail in laundry)
    {
        trigger fax machine = activate note(2)
    }

    if(play exits front door)
    {
        load scene two
    }

SCENE TWO

    Start - inside bedroom upstairs (door open, lights on)
    (upstairs all lit / downstairs = lights off)

    if(family photo has been picked up)
    {
        activate torch (therefore can go downstairs)
    }

    if(radio = on && pickup bill) //this is in the study
    {
        stop(radio)
        open front door
    }

    if(lawn toy, bloodstain, driveway toy)
    {
        Activate newspaper + mail
        Acivate dark house
    }

    if(read newspaper + mail)
    {
        trigger fax machine
        activate note(3)
    }


    if(read note(3))
    {
        trigger portrait smash audio + gameObject
    }

    if(pick up portrait)
    {
        trigger audio(upstairs noise)
    }

    if(passports && riped out poisonous plant page)
    {
        trigger light in sisters room
        activate objects in sisters room
    }

    if(toy in sisters room)
    {
        trigger fax machine audio
        activate note(4)
    }

    if(note(4))
    {
        trigger radio audio
        activate cups filled with poison
    }

    if(drink poison)
    {
        screne fade to black (player passes out)
        phone rings
        screne fade in
    }

    player crawls to phone
    phone plays 000 call audio
    screne fade to black
    game over

*/

