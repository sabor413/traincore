<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet version="1.0"
  xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
  xmlns:sc="http://www.sitecore.net/sc"
  xmlns:sql="http://www.sitecore.net/sql"
  exclude-result-prefixes="sc sql">

  <!-- output directives -->
  <xsl:output method="html" indent="no" encoding="UTF-8"  />

  <!-- sitecore parameters -->
  <xsl:param name="lang" select="'en'"/>
  <xsl:param name="id" select="''"/>
  <xsl:param name="sc_item"/>
  <xsl:param name="sc_currentitem"/>

  <!-- entry point -->
  <xsl:template match="*">
    <xsl:variable name="itinerary" select="$sc_item/descendant-or-self::item[@tid = '{EC705A7F-B1DD-46AC-9EEF-0E377B31A740}']" />
    <xsl:if test="sc:fld('Page Heading', $itinerary) != ''">
      <h2>
        <sc:text field="Page Heading" select="$itinerary" />
      </h2>
    </xsl:if>
    <xsl:variable name="count" select="count($sc_currentitem/descendant-or-self::item[@tid = '{D06FE9E2-47FA-405D-B7C9-A7F67CA77860}'])" />
    <xsl:if test="$count > 0">    
      <ul class="itinerary">
        <xsl:for-each select="$sc_currentitem/descendant-or-self::item[@tid = '{D06FE9E2-47FA-405D-B7C9-A7F67CA77860}']">
          <xsl:if test="sc:fld('Page Heading', .) != ''">
            <li>
              <h3>
                <sc:link>
                  <sc:text field="Page Heading" select="." />
                </sc:link>
              </h3>
            </li>
          </xsl:if>
          <sc:date field="Date" select="." />
          <sc:text field="Page Summary" select="." />
        </xsl:for-each>
      </ul>
    </xsl:if>
  </xsl:template>

</xsl:stylesheet>