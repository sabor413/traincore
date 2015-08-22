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

  <xsl:variable name="root" select="$sc_item/ancestor-or-self::item[@template = 'site folder']" />
  <xsl:variable name="navigation" select="sc:item(sc:fld('Footer Navigation Root', $root), $sc_currentitem)" />
  
  <!-- entry point -->

  <xsl:template match="*">
      <ul class="metaNavigation">
      <xsl:for-each select="$navigation/item">
        <xsl:choose>
        <xsl:when test="@template = 'simple item'">
          <xsl:if test="sc:fld('Item', .) != ''">
            <xsl:variable name="navigationItem" select="sc:item(sc:fld('Item', .), .)" />
            <xsl:if test="sc:fld('Hide From Navigation', $navigationItem) != 1">
            <li>
              <a href="{sc:path($navigationItem)}">
                <xsl:call-template name="iscurrent">
                  <xsl:with-param name="navigationitem" select="$navigationItem" />
                </xsl:call-template>
                <sc:text field="Navigation Title" select="$navigationItem" />
              </a>
            </li>
            </xsl:if>
          </xsl:if>
        </xsl:when>
        <xsl:when test="@template = 'simple link'">
          <li>
            <sc:link field="Link" select="." />
          </li>
        </xsl:when>
        </xsl:choose>
      </xsl:for-each>
      </ul>
  </xsl:template>

  <xsl:template name="iscurrent">
    <xsl:param name="navigationitem" />
    <xsl:if test="($sc_currentitem/ancestor-or-self::item/@id = $navigationitem/@id and $navigationitem[@templatename != 'Home']) or ($sc_currentitem/@id = $navigationitem/@id)">
      <xsl:attribute name="class">current</xsl:attribute>
    </xsl:if>
  </xsl:template>

</xsl:stylesheet>
