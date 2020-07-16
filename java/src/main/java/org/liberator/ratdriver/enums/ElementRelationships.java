package org.liberator.ratdriver.enums;

/**
 * Enumerations of relationships between elements
 */
@SuppressWarnings("unused")
public enum ElementRelationships
{
    /**
     * No relationship has been calculated
     */
    NoResponse,

    /**
     * No relationship, the two nodes do not belong to the same document
     */
    NoRelationship,

    /**
     * The first node (p1) is positioned after the second node (p2)
     */
    FirstElementAfterSecond,

    /**
     * The first node (p1) is positioned before the second node (p2)
     */
    FirstElementBeforeSecond,

    /**
     * The first node (p1) is positioned inside the second node (p2)
     */
    FirstElementInsideSecond,

    /**
     * The second node (p2) is positioned inside the first node (p1)
     */
    SecondElementInsideFirst,

    /**
     * No relationship, or the two nodes are two attributes on the same element
     */
    MayBeSameElement
}
