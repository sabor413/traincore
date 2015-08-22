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

  <!-- entry point -->
  <xsl:template match="*">
      <xsl:for-each select="$sc_currentitem/item[sc:fld('__created',.)]">
        <div class="sectionItem">
          <xsl:if test="sc:fld('Page Heading', .) != ''">
            <h2>
              <sc:link>
                <sc:text field="Page Heading" select="." />
              </sc:link>
            </h2>
          </xsl:if>
          <sc:link>
            <sc:image field="Summary Image" select="." />
          </sc:link>
          <sc:text field="Page Summary" select="." />
        </div>
      </xsl:for-each>
  </xsl:template>

</xsl:stylesheet>
