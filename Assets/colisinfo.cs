using System.Collections.Generic;
using UnityEngine;

public class colisinfo : MonoBehaviour
{

    public List<string> Interacted = new List<string>();

    public void OnTriggerEnter(Collider other)
    {
        // add tag 'klocek' for cubes
        if (other.tag == "scianka")
        {
            Debug.Log(other.tag);
            // if the cube has interacted with the cutter it won't be interacting second time with the same one
            if (Interacted.Contains(other.gameObject.transform.parent.name))
                Debug.Log("Było już");
            else
            {

                Interacted.Add(other.gameObject.transform.parent.name);

                // Debug.Log(other.gameObject.transform.parent.position);

                var collisionPoint = other.gameObject.GetComponent<Collider>().ClosestPointOnBounds(transform.position);

                var scianka = other.gameObject.transform.parent;


                scianka.GetComponent<bounds>().Scale.xScale = scianka.transform.localScale.x;
                scianka.GetComponent<bounds>().Scale.yScale = scianka.transform.localScale.y;
                scianka.GetComponent<bounds>().Scale.zScale = scianka.transform.localScale.z;


                //Using only 4 sides
                Vector3 pos = scianka.transform.position;

                if (other.name == scianka.GetComponent<bounds>().x1.name)
                {

                    SpawnNewKlocek(other, scianka, pos, collisionPoint);
                }

                if (other.name == scianka.GetComponent<bounds>().x2.name)
                {
                    SpawnNewKlocek(other, scianka, pos, collisionPoint);
                }


                /**
                                if (other == scianka.GetComponent<bounds>().y2)
                                {
                                    scianka.transform.localScale = new Vector3(1, (float)0.5, 1);
                                }

                                if (other == scianka.GetComponent<bounds>().y4)
                                {
                                    scianka.transform.localScale = new Vector3(1, (float)0.5, 1);
                                }
                **/

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
    public void SpawnNewKlocek(Collider other, Transform scianka, Vector3 pos, Vector3 collisionPoint)
    {

        Debug.Log(other.name);
        // scianka.transform.localScale = new Vector3( scianka.transform.localScale.x/2, scianka.transform.localScale.y, scianka.transform.localScale.z);

        Vector3 leftPoint = scianka.position - (Vector3.right * scianka.transform.localScale.y / 2);
        Vector3 rightPoint = scianka.position + (Vector3.right * scianka.transform.localScale.y / 2);

        Vector3 CutPosition = new Vector3(transform.position.x, pos.y, pos.z);


        GameObject praweNowa = Instantiate(other.gameObject.transform.parent.gameObject, new Vector3(rightPoint.x, scianka.position.y, scianka.position.z), Quaternion.identity);
        float prawyDistance = (Vector3.Distance(CutPosition, rightPoint));

        praweNowa.transform.localScale = new Vector3(prawyDistance, scianka.transform.localScale.y, scianka.transform.localScale.z);



        GameObject leweNowa = Instantiate(other.gameObject.transform.parent.gameObject, new Vector3(leftPoint.x, scianka.position.y, scianka.position.z), Quaternion.identity);
        float lewyDistance = (Vector3.Distance(CutPosition, leftPoint)) ;

        leweNowa.transform.localScale = new Vector3(lewyDistance, scianka.transform.localScale.y, scianka.transform.localScale.z);



        Interacted.Add(praweNowa.name);
        Interacted.Add(leweNowa.name);

        Destroy(other.gameObject.transform.parent.gameObject);
    }
}
