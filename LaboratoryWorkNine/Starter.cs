using LaboratoryWorkNine;

TreeImpl<int> impl = new TreeImpl<int>(1);
impl.SetDataOnLeft(1);
impl.SetDataOnRight(2);
impl.SetDataToPath(5, TreeBranch.Right, TreeBranch.Left);
impl.SetDataToPath(3, TreeBranch.Right, TreeBranch.Right);
impl.SetDataToPath(3, TreeBranch.Left, TreeBranch.Left);
impl.SetDataToPath(3, TreeBranch.Left, TreeBranch.Left, TreeBranch.Left);

Console.WriteLine(impl);
impl.SwapTree();
Console.WriteLine(impl);