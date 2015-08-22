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
  <xsl:param name="testitems" />
  <xsl:param name="testtext" />
  <xsl:variable name="home" select="$sc_currentitem/ancestor-or-self::item[@tid='{6D33B111-0B0C-42AF-BC95-A4EEF0B91750}']" />

  <xsl:template match="*">
    <!-- Get the root item -->
    <xsl:variable name="section" select="$sc_currentitem/ancestor-or-self::item[@parentid = $home/@id]"/>
    <!-- Render the menu from the root item and downwards -->
    <xsl:call-template name="renderMenu">
      <xsl:with-param name="root" select="$section"/>
      <xsl:with-param name="level" select="0"/>
      <xsl:with-param name="items" select="$section/item"/>
    </xsl:call-template>
  </xsl:template>

  <xsl:template name="renderMenu">
    <xsl:param name="root"/>
    <xsl:param name="level"/>
    <xsl:param name="items"/>

    <xsl:if test="$items">
      <ul class="level{$level}">
        <xsl:for-each select="$items">
          <xsl:variable name="subItems" select="$items/item"/>
          <li>
            <!-- Apply CSS to the link -->
            <xsl:variable name="selectedClass">
              <!-- Item has children -->
              <xsl:if test="$subItems">children</xsl:if>
              <!-- Item is open (one of it's children is the current page -->
              <xsl:if test="$subItems and @id = $sc_currentitem/ancestor-or-self::item/@id"> open</xsl:if>
              <!-- Item is the current page -->
              <xsl:if test="@id = $sc_currentitem/@id"> selected</xsl:if>
            </xsl:variable>

            <!-- Write link including generated CSS tag -->
            <a href="{sc:path(.)}" class="{$selectedClass}">
              <sc:text field="Navigation Title"/>
            </a>

            <!-- Go further down the tree and render children -->
            <xsl:if test="@id = sc_currentitem/ancestor-or-self::item/@id">
              <xsl:call-template name="renderMenu">
                <xsl:with-param name="root" select="."/>
                <xsl:with-param name="level" select="$level+1"/>
                <xsl:with-param name="items" select="$subItems"/>
              </xsl:call-template>
            </xsl:if>
          </li>
        </xsl:for-each>
      </ul>
    </xsl:if>
  </xsl:template>

</xsl:stylesheet>
