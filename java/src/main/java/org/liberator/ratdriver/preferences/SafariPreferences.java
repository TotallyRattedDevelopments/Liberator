package org.liberator.ratdriver.preferences;

@SuppressWarnings("CanBeFinal")
public class SafariPreferences extends BasePreferences {

    @SuppressWarnings("unused")
    public SafariPreferences(){
        AutomaticInspection = null;
        AutomaticProfiling = null;
        TechnologyPreview = null;
        Port = null;
    }

    public Boolean AutomaticInspection;

    public Boolean AutomaticProfiling;

    public Boolean TechnologyPreview;

    public Integer Port;
}
