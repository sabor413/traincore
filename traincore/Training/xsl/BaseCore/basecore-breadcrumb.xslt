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
    <p class="breadcrumb">
      <xsl:for-each select="ancestor-or-self::item">
        <xsl:if test="position() > 3 and @template != 'folder'">
          <xsl:choose>
            <xsl:when test="position() != last()">
              <sc:link>
                <xsl:call-template name="GetNavTitle" />
              </sc:link>
              <xsl:text> &#187; </xsl:text>
            </xsl:when>
            <xsl:otherwise>
              <xsl:call-template name="GetNavTitle" />
            </xsl:otherwise>
          </xsl:choose>
        </xsl:if>
      </xsl:for-each>
    </p>
  </xsl:template>

  <xsl:template name="GetNavTitle">
    <xsl:param name="item" select="." />
    <xsl:choose>
      <xsl:when test="sc:fld( 'Navigation Title', $item )">
        <sc:text field="Navigation Title" />
      </xsl:when>
      <xsl:otherwise>
        <xsl:value-of select="$item/@name" />
      </xsl:otherwise>
    </xsl:choose>
  </xsl:template>

</xsl:stylesheet>