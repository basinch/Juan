using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.GraphicsBuffer;

public class HorseScript : MonoBehaviour, IHorses
{
    private AIPath aiPath;
    public bool isFriend;
    public bool isGetiingRidden;
    public float horseSpeed = 3f;
    public GameObject[] lovedItem;
    public GameObject[] hatedItem;
    public SpriteRenderer emotionObject;
    [SerializeField] private Sprite happySprite;
    [SerializeField] private Sprite angrySprite;
    private AIDestinationSetter aiDestination;
    [HideInInspector] public Vector2 destinationVector;
    public GameObject targetContainer;
    private GameObject player;
    private PlayerMovement playerMovement;
    public bool isMoving;
    void Start()
    {
        aiDestination = GetComponent<AIDestinationSetter>();
        aiPath = GetComponent<AIPath>();
        horseSpeed = aiPath.maxSpeed;
        player = GameObject.FindWithTag("Player");
        playerMovement = player.GetComponent<PlayerMovement>();
    }
    private void FixedUpdate()
    {
        if(transform.eulerAngles == new Vector3(0, 0, 0))
        {
            if (isGetiingRidden && playerMovement.isMoving)
            {
                Vector3 desiredPosition = new Vector3(player.transform.position.x + 0.15f, player.transform.position.y + 1.05f, 0);
                Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, 1);
                transform.position = new Vector3(smoothedPosition.x, smoothedPosition.y, transform.position.z);
            }
        }
        else if(transform.eulerAngles == new Vector3(0, 180, 0))
        {
            if (isGetiingRidden && playerMovement.isMoving)
            {
                Vector3 desiredPosition = new Vector3(player.transform.position.x + -0.15f, player.transform.position.y + 1.05f, 0);
                Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, 1);
                transform.position = new Vector3(smoothedPosition.x, smoothedPosition.y, transform.position.z);
            }
        }

       

    }
    public void BeHappy()
    {
        if (!isFriend)
        {
            StartCoroutine(ChangeEmotion(happySprite));
            isFriend = true;
            aiPath.maxSpeed = horseSpeed;
            aiDestination.enabled = false;
            aiPath.enabled = false;
        }
    }
    public void BeAngry()
    {
        if(!isFriend)
        {
            StartCoroutine(ChangeEmotion(angrySprite));
            Debug.Log("angy");
            aiDestination.target = GetFurthestTarget().transform;
            aiPath.maxSpeed *= 3f;
        }
    }
    public void StartRiding()
    {
        if(isFriend && !isGetiingRidden)
        {
            isGetiingRidden = true;
            Debug.Log("ismet bindi");
            aiDestination.enabled= false;
            aiPath.enabled= false;
        }
    }
    public void StopRiding()
    {
        if (isGetiingRidden)
        {
            isGetiingRidden = false;
            Debug.Log("ismet indi");
            aiDestination.enabled = true;
            aiPath.enabled= true;
        }
    }
    public void GettingRidden()
    {

    }
    public float DistanceLeftToTarget()
    {
        destinationVector = new Vector2(aiDestination.target.position.x, aiDestination.target.position.y);
        float distanceFloat = Vector2.Distance(destinationVector, transform.position);
        return distanceFloat;
    }
    // Update is called once per frame
    void Update()
    {
        if((aiDestination.target == null || DistanceLeftToTarget() < 0.05f) && !isGetiingRidden)
        {
            Debug.Log("eseek");
            aiPath.maxSpeed = horseSpeed;
            aiDestination.target = PickRandomTarget().transform;
        }
    }
    public IEnumerator FadeIn()
    {
        float alphaVal = emotionObject.color.a;
        Color tmp = emotionObject.color;

        while (emotionObject.color.a > 0)
        {
            alphaVal -= 0.002f;
            tmp.a = alphaVal;
            emotionObject.color = tmp;

            yield return new WaitForSeconds(0.05f); // update interval
        }
    }
    public  IEnumerator FadeOut()
    {
        float alphaVal = emotionObject.color.a;
        Color tmp = emotionObject.color;

        while (emotionObject.color.a < 1)
        {
            alphaVal += 0.002f;
            tmp.a = alphaVal;
            emotionObject.color = tmp;

            yield return new WaitForSeconds(0.05f); // update interval
        }
    }
    public IEnumerator ChangeEmotion(Sprite emotionSprite)
    {
        emotionObject.sprite = emotionSprite;
        StartCoroutine(FadeIn());
        yield return new WaitForSeconds(1);
        StartCoroutine(FadeOut());
        emotionObject.sprite = null;
    }
    public GameObject PickRandomTarget()
    {
        if (targetContainer == null)
        {
            return null;
        }

        List<GameObject> childObjects = new List<GameObject>();

        foreach (Transform child in targetContainer.transform)
        {
            childObjects.Add(child.gameObject);
        }

        if (childObjects.Count > 0)
        {
            int randomIndex = Random.Range(0, childObjects.Count);
            return childObjects[randomIndex];
        }
        else
        {
            return null;
        }
    }
    public GameObject GetFurthestTarget()
    {
        if (targetContainer == null)
        {
            return null;
        }
        List<GameObject> childObjects = new List<GameObject>();

        foreach (Transform child in targetContainer.transform)
        {
            childObjects.Add(child.gameObject);
        }
        float maxDistance = 0f;
        GameObject furthestObject = null;

        foreach (GameObject child in childObjects)
        {
            float distance = Vector3.Distance(child.transform.position, transform.position);
            if (distance > maxDistance)
            {
                maxDistance = distance;
                furthestObject = child;
            }
        }
        return furthestObject;
    }
}
