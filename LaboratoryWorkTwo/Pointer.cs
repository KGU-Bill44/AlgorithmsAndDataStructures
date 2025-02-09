namespace LaboratoryWorkTwo;

public class Pointer
{
    private DistributedTree owner;
    private bool isFind;
    private int currentMin;

    public bool IsFind => isFind;

    public int Min
    {
        get
        {
            lock (this)
            {
                int min = owner.UseMin();
                ResetOwner();
                return min;
            }
        }
    }

    public void SetPotentialMinimum(DistributedTree potentialOwner)
    {
        lock (this)
        {
            if (potentialOwner.RunArray.Count <= 0) return;

            if (!isFind)
            {
                currentMin = potentialOwner.RunArray[0];
                this.owner = potentialOwner;
                isFind = true;
                return;
            }

            int potentialMin = potentialOwner.RunArray[0];
            if (currentMin <= potentialMin) return;
            this.owner = potentialOwner;
        }
    }

    private void ResetOwner()
    {
        owner = null;
        isFind = false;
    }
}