package org.liberator.ratdriver.entities;

import lombok.Getter;
import lombok.Setter;

/**
 * The measurements for elements
 */
public class ElementSize
{
    /**
     * Height of the element
     */
    @Getter
    @Setter
    public int Height;

    /**
     * Leftmost edge of the element
     */
    @Getter
    @Setter
    public int Left;

    /**
     * Topmost edge of the element
     */
    @Getter
    @Setter
    public int Top;

    /**
     * Width of the element
     */
    @Getter
    @Setter
    public int Width;
}
