package org.liberator.ratdriver.entities;


import lombok.Getter;
import lombok.Setter;

/**
 * Bounding client rectangle
 */
@Getter
@Setter
public class DomRectangle
{
    /**
     *Leftmost edge
     */
    @Getter @Setter
    public int Left;

    /**
     * Topmost edge
     */
    @Getter @Setter
    public int Top;

    /**
     * Rightmost edge
     */
    @Getter @Setter
    public int Right;

    /**
     * Bottom edge
     */
    @Getter @Setter
    public int Bottom;

    /**
     * X Co-ordinate
     */
    @Getter @Setter
    public int X;

    /**
     * Y Co-ordinate
     */
    @Getter @Setter
    public int Y;

    /**
     * Width of the element
     */
    @Getter @Setter
    public int Width;

    /**
     * Height of the element
     */
    @Getter @Setter
    public int Height;
}
