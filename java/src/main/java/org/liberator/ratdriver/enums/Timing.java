package org.liberator.ratdriver.enums;

@SuppressWarnings("unused")
public enum Timing {

    /**
     * Timing point not specified
     */
    NotSpecified,

    /**
     * Generic timing point
     */
    GenericTiming,

    /**
     * Timing point for instance creation
     */
    Instantiation,

    /**
     * Page load timing point
     */
    PageLoad,

    /**
     * Timing point for elements to be found
     */
    ElementFindTime
}
