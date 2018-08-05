using System.Collections.Generic;
using UnityEngine;

public class CutTheCube : MonoBehaviour
{
    private ExtremePointsAndList EPAL;

    public void Start()
    {
        EPAL = new ExtremePointsAndList();
    }

    public void OnTriggerEnter(Collider other)
    {
        // add tag 'klocek' for cubes
        if (other.tag == "scianka")
        {
            Debug.Log(other.tag);
            // if the cube has interacted with the cutter it won't be interacting second time with the same one
            if (!EPAL.Interacted.Contains(other.gameObject.transform.parent.name))
            {
                EPAL.Interacted.Add(other.gameObject.transform.parent.name);

                Vector3 collisionPoint = other.gameObject.GetComponent<Collider>().ClosestPointOnBounds(transform.position);

                var scianka = other.gameObject.transform.parent;

                scianka.GetComponent<bounds>().Scale.xScale = scianka.transform.localScale.x;
                scianka.GetComponent<bounds>().Scale.yScale = scianka.transform.localScale.y;
                scianka.GetComponent<bounds>().Scale.zScale = scianka.transform.localScale.z;


                //Using only 4 sides
                Vector3 pos = scianka.transform.position;

                if (other.name == scianka.GetComponent<bounds>().x1.name || other.name == scianka.GetComponent<bounds>().x2.name)
                {
                    SpawnNewKlocekX(other, scianka, pos, collisionPoint);
                }

        
                if (other.name == scianka.GetComponent<bounds>().y2.name || other.name == scianka.GetComponent<bounds>().y4.name)
                {
                    SpawnNewKlocekY(other, scianka, pos, collisionPoint);
                }


                /**
                 * All 6 sides would be usefull when cutting in 3D
                 * 
                if (other == scianka.GetComponent<bounds>().y3)
                    Debug.Log("y3");
                if (other == scianka.GetComponent<bounds>().y1)
                    Debug.Log("y1");
                **/


            }


        }
        else
            Debug.Log("To nie scianka");
    }

    //for the X1 and X2
    public void SpawnNewKlocekX(Collider other, Transform scianka, Vector3 pos, Vector3 collisionPoint)
    {
        //right and left bounds
        Vector3 leftPoint = scianka.position - (Vector3.right * scianka.transform.localScale.x / 2);
        Vector3 rightPoint = scianka.position + (Vector3.right * scianka.transform.localScale.x / 2);

        Vector3 CutPosition = new Vector3(transform.position.x, pos.y, pos.z);


        GameObject praweNowa = Instantiate(other.gameObject.transform.parent.gameObject, new Vector3((rightPoint.x + CutPosition.x)/2, scianka.position.y, scianka.position.z), scianka.rotation);
        float prawyDistance = (Vector3.Distance(CutPosition, rightPoint));

        praweNowa.transform.localScale = new Vector3(prawyDistance, scianka.transform.localScale.y, scianka.transform.localScale.z);



        GameObject leweNowa = Instantiate(other.gameObject.transform.parent.gameObject, new Vector3((leftPoint.x + CutPosition.x)/2, scianka.position.y, scianka.position.z), scianka.rotation);
        float lewyDistance = (Vector3.Distance(CutPosition, leftPoint)) ;

        leweNowa.transform.localScale = new Vector3(lewyDistance, scianka.transform.localScale.y, scianka.transform.localScale.z);


        AddToList(praweNowa.name, leweNowa.name, EPAL.Interacted);

        Destroy(other.gameObject.transform.parent.gameObject);
    }

    //for the Y2 and Y4
    public void SpawnNewKlocekY(Collider other, Transform scianka, Vector3 pos, Vector3 collisionPoint)
    {
        //right and left bounds
        Vector3 leftPoint = scianka.position - (Vector3.right * scianka.transform.localScale.y / 2);
        Vector3 rightPoint = scianka.position + (Vector3.right * scianka.transform.localScale.y / 2);

        Vector3 CutPosition = new Vector3(transform.position.x, pos.y, pos.z);


        GameObject praweNowa = Instantiate(other.gameObject.transform.parent.gameObject, new Vector3((rightPoint.x + CutPosition.x) / 2, scianka.position.y, scianka.position.z), scianka.rotation);
        float prawyDistance = (Vector3.Distance(CutPosition, rightPoint));

        praweNowa.transform.localScale = new Vector3(scianka.transform.localScale.x, prawyDistance, scianka.transform.localScale.z);



        GameObject leweNowa = Instantiate(other.gameObject.transform.parent.gameObject, new Vector3((leftPoint.x + CutPosition.x) / 2, scianka.position.y, scianka.position.z), scianka.rotation);
        float lewyDistance = (Vector3.Distance(CutPosition, leftPoint));

        leweNowa.transform.localScale = new Vector3(scianka.transform.localScale.x, lewyDistance, scianka.transform.localScale.z);


        AddToList(praweNowa.name, leweNowa.name, EPAL.Interacted);

        Destroy(other.gameObject.transform.parent.gameObject);
    }


    public void AddToList(string prawy, string lewy, List<string> Interact)
    {
        Interact.Add(prawy);
        Interact.Add(lewy);
    }
}
