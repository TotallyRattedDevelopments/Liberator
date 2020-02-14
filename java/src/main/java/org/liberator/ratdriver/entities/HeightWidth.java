package org.liberator.ratdriver.entities;


import lombok.Getter;
import lombok.Setter;

/**
 * Represents the offsets for the element
 */
@SuppressWarnings("unused")
public class HeightWidth
{
    /**
     * The offset height of the element
     */
    @Getter
    @Setter
    public int Height;

    /**
     * The offset width of the element
     */
    @Getter
    @Setter
    public int Width;
}
