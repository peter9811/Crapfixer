using System.Collections.Generic;
using Crapfixer;

public class FeatureNode
{
    public string Name { get; set; }
    public bool IsCategory => Feature == null;
    public FeatureBase Feature { get; }
    public List<FeatureNode> Children { get; set; } = new List<FeatureNode>();

    // Constructor for categories
    public FeatureNode(string name)
    {
        Name = name;
    }

    // Constructor for actual features
    public FeatureNode(FeatureBase feature)
    {
        Feature = feature;
        Name = feature.ID(); // Use the ID as the name
    }
}
