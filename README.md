# Roku Feed Manager v0.02
_Windows Forms application to create, validate, and modify Roku Direct Publisher Feed files._

<p>This application is designed to maintain a content database to swiftly produce and modify Roku Direct Publisher Feed files used in populating the content of Roku channels. This file in JSON format contains metadata for every video served through the Roku platform.</p>

https://developer.roku.com/docs/specs/direct-publisher-feed-specs/json-dp-spec.md#direct-publisher-feed-schema

This application features a database of video, audio, and graphic assets with a tree structure for asset management. The user can maintain several channels through the application.

## Development Steps

Data Definition:  
  - Define the core JSON structure as C# classes.
  - Define a relational database containing the content data.

Create a management console with the following features:
  - Creation, modification, and deletion of Channels and JSON feeds.
  - Creation, modification, and deletion of Content assets

## Representing the feed's JSON schema as a C# Class

### root
<table>
<tr>
<td><p>Field</p></td>
<td><p>Type</p></td>
<td><p>Required</p></td>
<td><p>Description</p></td>
</tr>
  
  <tr><td><p>providerName</p></td><td><p>string</p></td><td><p>Required</p></td><td><p>The name of the feed provider. E.g.: &ldquo;Acme Productions&rdquo;.</p></td></tr>
  <tr><td><p>lastUpdated</p></td><td><p>string</p></td><td><p>Required</p></td><td><p>The date that the feed was last modified in<a href="https://www.google.com/url?q=http://www.iso.org/iso/home/standards/iso8601.htm&amp;sa=D&amp;source=editors&amp;ust=1735580039363387&amp;usg=AOvVaw0DEQlGOPjBW_7SY8aSieqv">&nbsp;</a><a href="https://www.google.com/url?q=http://www.iso.org/iso/home/standards/iso8601.htm&amp;sa=D&amp;source=editors&amp;ust=1735580039363523&amp;usg=AOvVaw2An-CzaSNnFzZUljZmvDIb">ISO 8601</a>&nbsp;format: {YYYY}-{MM}-{DD}T{hh}:{mm}:{ss}+{TZ}. For example, 2020-11-11T22:21:37+00:00</p></td></tr>
  <tr><td><p>language</p></td><td><p>string</p></td><td><p>Required</p></td><td><p>The language the channel uses for all its information and descriptions. (e.g., &ldquo;en&rdquo;, &ldquo;en-US&rdquo;, &ldquo;es&rdquo;, etc.). ISO 639 alpha-2 or alpha-3 language code string.</p></td></tr>
  <tr><td><p>movies</p></td><td><p><a href="https://www.google.com/url?q=https://developer.roku.com/docs/specs/direct-publisher-feed-specs/json-dp-spec.md%23movie&amp;sa=D&amp;source=editors&amp;ust=1735580039365214&amp;usg=AOvVaw0HQkXUt0baoMxcSI451Kdr">Movie Object</a></p></td><td><p>Required*</p></td><td><p>A list of one or more movies.</p></td></tr>
  <tr><td><p>liveFeeds</p></td><td><p><a href="https://www.google.com/url?q=https://developer.roku.com/docs/specs/direct-publisher-feed-specs/json-dp-spec.md%23livefeed&amp;sa=D&amp;source=editors&amp;ust=1735580039366320&amp;usg=AOvVaw0-iUwW8o_VF3fzK7iTKXgZ">LiveFeeds Object</a></p></td><td><p>Required*</p></td><td><p>A list of one or more live linear streams.</p></td></tr>
  <tr><td><p>series</p></td><td><p><a href="https://www.google.com/url?q=https://developer.roku.com/docs/specs/direct-publisher-feed-specs/json-dp-spec.md%23series&amp;sa=D&amp;source=editors&amp;ust=1735580039367322&amp;usg=AOvVaw3ihz2aXVFkF2QxPr9yPsgJ">Series Object</a></p></td><td><p>Required*</p></td><td><p>A list of one or more series. Series are episodic in nature and would include TV shows, daily/weekly shows, etc.</p></td></tr>
  <tr><td><p>shortFormVideos</p></td><td><p><a href="https://www.google.com/url?q=https://developer.roku.com/docs/specs/direct-publisher-feed-specs/json-dp-spec.md%23shortformvideo&amp;sa=D&amp;source=editors&amp;ust=1735580039368311&amp;usg=AOvVaw3Lvj2tW2-8eeTOjoQb-JLn">ShortFormVideo Object</a></p></td><td><p>Required*</p></td><td><p>A list of one or more short-form videos. Short-form videos are usually less than 15 minutes long and are not TV Shows or Movies.</p></td></tr>
  <tr><td><p>tvSpecials</p></td><td><p><a href="https://www.google.com/url?q=https://developer.roku.com/docs/specs/direct-publisher-feed-specs/json-dp-spec.md%23tvspecial&amp;sa=D&amp;source=editors&amp;ust=1735580039369313&amp;usg=AOvVaw0EbFYN1Z6tF_r5dOCUSUOZ">TV Special Object</a></p></td><td><p>Required*</p></td><td><p>A list of one or more TV Specials. TV Specials are one-time TV programs that are not part of a series.</p></td></tr>
  <tr><td><p>categories</p></td><td><p><a href="https://www.google.com/url?q=https://developer.roku.com/docs/specs/direct-publisher-feed-specs/json-dp-spec.md%23category&amp;sa=D&amp;source=editors&amp;ust=1735580039370300&amp;usg=AOvVaw1RJkNiWQgoFfJIFZ6BMsst">Category Object</a></p></td><td><p>Optional</p></td><td><p>An ordered list of one or more categories that will show up in your Roku Channel. Categories may also be manually specified within Direct Publisher if you do not want to provide them directly in the feed. Each time the feed is updated it will refresh the categories.</p></td></tr>
  <tr><td><p>playlists</p></td><td><p><a href="https://www.google.com/url?q=https://developer.roku.com/docs/specs/direct-publisher-feed-specs/json-dp-spec.md%23playlist&amp;sa=D&amp;source=editors&amp;ust=1735580039371273&amp;usg=AOvVaw0P_XuszUkhUik4dZYihkCt">Playlist Object</a></p></td><td><p>Optional</p></td><td><p>A list of one or more playlists. They are useful for creating manually ordered categories inside your channel.</p></td></tr>
</table>

### movie
<table>
<tr>
<td><p>Field</p></td>
<td><p>Type</p></td>
<td><p>Required</p></td>
<td><p>Description</p></td>
</tr>

<tr class="c22"><td class="c12"><p class="c0"><span class="c3">id</span></p></td><td class="c8 c24"><p class="c0"><span class="c3">string</span></p></td><td class="c5"><p class="c0"><span class="c3">Required</span></p></td><td class="c16 c24"><p class="c0"><span class="c3 c4">An immutable string reference ID for the movie that does not exceed 50 characters. This should serve as a unique identifier for the movie across different locales.</span></p><p class="c0"><span class="c3">Once created, the ID for the content item may not be changed.</span></p></td></tr>

<tr class="c15"><td class="c13"><p class="c0"><span class="c3">title</span></p></td><td class="c8 c14"><p class="c0"><span class="c3">string</span></p></td><td class="c2"><p class="c0"><span class="c3">Required</span></p></td><td class="c9"><p class="c0"><span class="c3">The movie title in plain text. This field is used for matching in Roku Search. Do not include extra information such as year, version label, and so on.</span></p></td></tr>

<tr class="c10"><td class="c12"><p class="c0"><span class="c3">content</span></p></td><td class="c8"><p class="c0"><span class="c11"><a class="c7" href="https://www.google.com/url?q=https://developer.roku.com/docs/specs/direct-publisher-feed-specs/json-dp-spec.md%23content&amp;sa=D&amp;source=editors&amp;ust=1735580784442829&amp;usg=AOvVaw2mJTfn7lOnctlQo_Rxf_2p">Content Object</a></span></p></td><td class="c5"><p class="c0"><span class="c3">Required</span></p></td><td class="c16 c24"><p class="c0"><span class="c3">The video content, such as the URL of the video file, subtitles, and so on.</span></p></td></tr>

<tr class="c10"><td class="c13"><p class="c0"><span class="c3">genres</span></p></td><td class="c8 c14"><p class="c0"><span class="c3">array</span></p></td><td class="c2"><p class="c0"><span class="c3">Required</span></p></td><td class="c16"><p class="c0"><span>A list of strings describing the genre(s) of the movie. Must be one of the values listed in</span><span><a class="c7" href="https://www.google.com/url?q=https://developer.roku.com/docs/specs/direct-publisher-feed-specs/json-dp-spec.md%23genres&amp;sa=D&amp;source=editors&amp;ust=1735580784444002&amp;usg=AOvVaw3uYO4VvX59EJWHs4ZGQx2q">&nbsp;</a></span><span class="c11"><a class="c7" href="https://www.google.com/url?q=https://developer.roku.com/docs/specs/direct-publisher-feed-specs/json-dp-spec.md%23genres&amp;sa=D&amp;source=editors&amp;ust=1735580784444142&amp;usg=AOvVaw3CMOZdpjo9ZbNH7hnJCPfK">genres</a></span><span>.</span></p></td></tr>

<tr class="c15"><td class="c12"><p class="c0"><span class="c3">thumbnail</span></p></td><td class="c8 c24"><p class="c0"><span class="c3">string</span></p></td><td class="c5"><p class="c0"><span class="c3">Required</span></p></td><td class="c16 c24"><p class="c0"><span class="c3">The URL of the thumbnail for the movie. This is used within the channel and in search results. Image dimensions must be at least 800x450 (width x height, 16x9 aspect ratio).</span></p></td></tr>

<tr class="c26"><td class="c13"><p class="c0"><span class="c3">releaseDate</span></p></td><td class="c8 c14"><p class="c0"><span class="c3">string</span></p></td><td class="c2"><p class="c0"><span class="c3">Required</span></p></td><td class="c16"><p class="c0"><span>The date the movie was initially released or first aired. This field is used to sort programs chronologically and group related content in Roku Search. Conforms to the</span><span><a class="c7" href="https://www.google.com/url?q=http://www.iso.org/iso/home/standards/iso8601.htm&amp;sa=D&amp;source=editors&amp;ust=1735580784445589&amp;usg=AOvVaw1V0bnZW4_cmXMabV8C7Ek3">&nbsp;</a></span><span class="c11"><a class="c7" href="https://www.google.com/url?q=http://www.iso.org/iso/home/standards/iso8601.htm&amp;sa=D&amp;source=editors&amp;ust=1735580784445670&amp;usg=AOvVaw2Mgc4KeNal4MBviNX24xxp">ISO 8601</a></span><span>&nbsp;format: {YYYY}-{MM}-{DD}. For example, 2020-11-11</span></p></td></tr>

<tr class="c10"><td class="c12"><p class="c0"><span class="c3">shortDescription</span></p></td><td class="c8 c24"><p class="c0"><span class="c3">string</span></p></td><td class="c5"><p class="c0"><span class="c3">Required</span></p></td><td class="c16 c24"><p class="c0"><span class="c3">A movie description that does not exceed 200 characters. The text will be clipped if longer.</span></p></td></tr>

<tr class="c15"><td class="c13"><p class="c0"><span class="c3">longDescription</span></p></td><td class="c8 c14"><p class="c0"><span class="c3">string</span></p></td><td class="c2"><p class="c0"><span class="c3">Required</span></p></td><td class="c9"><p class="c0"><span class="c3">A longer movie description that does not exceed 500 characters. The text will be clipped if longer. Must be different from shortDescription.</span></p></td></tr>

<tr class="c19"><td class="c12"><p class="c0"><span class="c3">tags</span></p></td><td class="c8 c24"><p class="c0"><span class="c3">array</span></p></td><td class="c5"><p class="c0"><span class="c3">Optional</span></p></td><td class="c16"><p class="c0"><span>A list of one or more tags (for example, &ldquo;dramas&rdquo;, &ldquo;korean&rdquo;, and so on). Each tag is a string and is limited to 20 characters. Tags are used to define what content will be shown within a</span><span><a class="c7" href="https://www.google.com/url?q=https://developer.roku.com/docs/specs/direct-publisher-feed-specs/json-dp-spec.md%23category&amp;sa=D&amp;source=editors&amp;ust=1735580784448365&amp;usg=AOvVaw3nWXUKnZR70fw04eJPMGMF">&nbsp;</a></span><span class="c11"><a class="c7" href="https://www.google.com/url?q=https://developer.roku.com/docs/specs/direct-publisher-feed-specs/json-dp-spec.md%23category&amp;sa=D&amp;source=editors&amp;ust=1735580784448498&amp;usg=AOvVaw3wmN6lI0O7hxFiQQj-vbSd">category</a></span><span>.</span></p></td></tr>

<tr class="c10"><td class="c13"><p class="c0"><span class="c3">credits</span></p></td><td class="c8"><p class="c0"><span class="c11"><a class="c7" href="https://www.google.com/url?q=https://developer.roku.com/docs/specs/direct-publisher-feed-specs/json-dp-spec.md%23credit&amp;sa=D&amp;source=editors&amp;ust=1735580784449050&amp;usg=AOvVaw1V-FwbBFxe56q1IR_y6rOa">Credit Object</a></span></p></td><td class="c2"><p class="c0"><span class="c3">Optional</span></p></td><td class="c9"><p class="c0"><span class="c3">One or more credits. The cast and crew of the movie.</span></p></td></tr>

<tr class="c10"><td class="c12"><p class="c0"><span class="c3">rating</span></p></td><td class="c8"><p class="c0"><span class="c11"><a class="c7" href="https://www.google.com/url?q=https://developer.roku.com/docs/specs/direct-publisher-feed-specs/json-dp-spec.md%23rating&amp;sa=D&amp;source=editors&amp;ust=1735580784449976&amp;usg=AOvVaw0yQd7PF9lbXzEWCf_Kx3GB">Rating Object</a></span></p></td><td class="c5"><p class="c0"><span class="c3">Required</span></p></td><td class="c16 c24"><p class="c0"><span class="c3">A parental rating for the content.</span></p></td></tr>

<tr class="c10"><td class="c13"><p class="c0"><span class="c3">externalIds</span></p></td><td class="c8"><p class="c0"><span class="c11"><a class="c7" href="https://www.google.com/url?q=https://developer.roku.com/docs/specs/direct-publisher-feed-specs/json-dp-spec.md%23externalids&amp;sa=D&amp;source=editors&amp;ust=1735580784451127&amp;usg=AOvVaw1GBWIsevOYPzDqjxWPvo36">External ID Object</a></span></p></td><td class="c2"><p class="c0"><span class="c3">Optional</span></p></td><td class="c9"><p class="c0"><span class="c3">One or more third-party metadata provider IDs.</span></p></td></tr>
</table>

### content

<table>
<tr>
<td><p>Field</p></td>
<td><p>Type</p></td>
<td><p>Required</p></td>
<td><p>Description</p></td>
</tr>

<tr>
<td><p>dateAdded</p></td>
<td><p>string</p></td>
<td><p>Required</p></td>
<td><p>The date the video was added to the library in the<a href="https://www.google.com/url?q=http://www.iso.org/iso/home/standards/iso8601.htm&amp;sa=D&amp;source=editors&amp;ust=1735592446234332&amp;usg=AOvVaw3iQIGOd3r2ahH2FSc5rP5-">&nbsp;</a><a href="https://www.google.com/url?q=http://www.iso.org/iso/home/standards/iso8601.htm&amp;sa=D&amp;source=editors&amp;ust=1735592446234416&amp;usg=AOvVaw3aVZ1fU_bhVqo1DYEVgp-P">ISO 8601</a>&nbsp;format: {YYYY}-{MM}-{DD}T{hh}:{mm}:{ss}+{TZ}. For example, 2020-11-11T22:21:37+00:00.</p><p></p><p>This information is used to generate the &ldquo;Recently Added&rdquo; category.</p></td>
</tr>

<tr>
<td><p>videos</p></td>
<td><p><a href="https://www.google.com/url?q=https://developer.roku.com/docs/specs/direct-publisher-feed-specs/json-dp-spec.md%23video&amp;sa=D&amp;source=editors&amp;ust=1735592446235008&amp;usg=AOvVaw0WY4jHnA1I2NVvsVaK3Vzp">Video Object</a></p></td>
<td><p>Required</p></td>
<td><p>One or more video files. For non-adaptive streams, the same video may be specified with different qualities so the Roku player can choose the best one based on bandwidth.</p></td>
</tr>

<tr>
<td><p>duration</p></td>
<td><p>integer</p></td>
<td><p>Required</p></td>
<td><p>Runtime in seconds.</p></td>
</tr>

<tr>
<td><p>captions</p></td>
<td><p><a href="https://www.google.com/url?q=https://developer.roku.com/docs/specs/direct-publisher-feed-specs/json-dp-spec.md%23caption&amp;sa=D&amp;source=editors&amp;ust=1735592446236547&amp;usg=AOvVaw1cIHNchwsSN7Jsze7ZiJIP">Caption Object</a></p></td>
<td><p>Required for live broadcast replays</p></td>
<td><p>Supported formats are described in<a href="https://www.google.com/url?q=https://developer.roku.com/docs/developer-program/media-playback/closed-caption.md&amp;sa=D&amp;source=editors&amp;ust=1735592446237018&amp;usg=AOvVaw3U0vEq71hRsALV-jveTB0Y">&nbsp;</a><a href="https://www.google.com/url?q=https://developer.roku.com/docs/developer-program/media-playback/closed-caption.md&amp;sa=D&amp;source=editors&amp;ust=1735592446237095&amp;usg=AOvVaw09N4Fqi4ZiQ9e42AlPY5WK">Closed Caption Support</a>.</p></td>
</tr>

<tr>
<td><p>trickPlayFiles</p></td>
<td><p><a href="https://www.google.com/url?q=https://developer.roku.com/docs/specs/direct-publisher-feed-specs/json-dp-spec.md%23trickplayfile&amp;sa=D&amp;source=editors&amp;ust=1735592446237526&amp;usg=AOvVaw1Jt1i-1OTcn-VZAxgGL9lP">Trickplay File Object</a></p></td>
<td><p>Optional</p></td>
<td><p>The trickplay file(s) that displays images as a user scrubs through a video, in Roku&rsquo;s BIF format. Trickplay files in multiple qualities can be provided.</p></td>
</tr>

<tr>
<td><p>language</p></td>
<td><p>string</p></td>
<td><p>Required</p></td>
<td><p>The language in which the video was originally produced (e.g., &ldquo;en&rdquo;, &ldquo;en-US&rdquo;, &ldquo;es&rdquo;, etc). ISO 639 alpha-2 or alpha-3 language code string.</p></td>
</tr>

<tr>
<td><p>validityPeriodStart</p></td>
<td><p>string</p></td>
<td><p>Optional</p></td>
<td><p>The date when the content should become available in<a href="https://www.google.com/url?q=http://www.iso.org/iso/home/standards/iso8601.htm&amp;sa=D&amp;source=editors&amp;ust=1735592446239085&amp;usg=AOvVaw3jkBKQAspdAkDA3bt8oFOi">&nbsp;</a><a href="https://www.google.com/url?q=http://www.iso.org/iso/home/standards/iso8601.htm&amp;sa=D&amp;source=editors&amp;ust=1735592446239146&amp;usg=AOvVaw3KKGgWbwqI_OI-yvyBiZwT">ISO 8601</a>format: {YYYY}-{MM}-{DD}T{hh}:{mm}:{ss}+{TZ}. For example, 2020-11-11T22:21:37+00:00</p></td>
</tr>

<tr>
<td><p>validityPeriodEnd</p></td>
<td><p>string</p></td>
<td><p>Optional</p></td>
<td><p>The date when the content is no longer available in<a href="https://www.google.com/url?q=http://www.iso.org/iso/home/standards/iso8601.htm&amp;sa=D&amp;source=editors&amp;ust=1735592446239796&amp;usg=AOvVaw3pHONb0_yoJj6rGbgQ2O5Z">&nbsp;</a><a href="https://www.google.com/url?q=http://www.iso.org/iso/home/standards/iso8601.htm&amp;sa=D&amp;source=editors&amp;ust=1735592446239850&amp;usg=AOvVaw2aWZ8GV8I_bHQ_t4Gql-Q2">ISO 8601</a>format: {YYYY}-{MM}-{DD}T{hh}:{mm}:{ss}+{TZ}. For example, 2020-11-11T22:21:37+00:00</p></td>
</tr>

<tr>
<td><p>adBreaks</p></td>
<td><p>string</p></td>
<td><p>Required if monetizing content</p></td>
<td><p>One or more time codes. Represents a time duration from the beginning of the video where an ad shows up. Conforms to the format: {hh}:{mm}:{ss} and in the form of an SCTE-35 marker. See each content type for its ad policy.</p></td>
</tr>
</table>

### video
<table><tr>
<td ><p>Field</p></td>
<td ><p>Type</p></td>
<td ><p>Required</p></td>
<td ><p>Description</p></td>
</tr>

<tr>
<td ><p>url</p></td>
<td ><p>string</p></td>
<td ><p>Required</p></td>
<td ><p>The URL of the video itself. The URL must use the secure protocol prefix &quot;https://&quot;.</p><p></p><p>All videos must play across multiple devices.</p><p></p><p>The video should be served from a CDN (Content Distribution Network).</p><p></p><p>Supported formats are described in<a href="https://www.google.com/url?q=https://developer.roku.com/docs/specs/media/streaming-specifications.md&amp;sa=D&amp;source=editors&amp;ust=1735595249120379&amp;usg=AOvVaw2hctLjn8oRt4G0ZiuuGhQ6">&nbsp;</a><a href="https://www.google.com/url?q=https://developer.roku.com/docs/specs/media/streaming-specifications.md&amp;sa=D&amp;source=editors&amp;ust=1735595249120553&amp;usg=AOvVaw1Z1UQYm2bzyCXSSwzl987e">Audio and Video Support</a>.</p></td>
</tr>

<tr>
<td ><p>quality</p></td>
<td ><p>enum</p></td>
<td ><p>Required</p></td>
<td ><p>Must be one of the following display types:SD: Anything under 720p</p><p>HD: 720p</p><p>FHD: 1080p</p><p>UHD: 4K</p><p>If your stream uses an adaptive bitrate, set the quality to the highest available one. Provide at least six profiles of video quality with the bitrate ranging from 192 to at least 4000. Roku needs the low end to support mobile/web playback and also recommends the high end in the 5000 range to support 4k TVs. The ideal bitrate ladder is included below, along with resolutions:ResolutionBitrate (video + audio)1920X1080 5800 1920X1080 4300 1280X720 3500 1280X720 2750 720X404 1750 720X404 1100 512X288 700 384X216 400 384X216 192</p></td>
</tr>

<tr>
<td ><p>videoType</p></td>
<td ><p>enum</p></td>
<td ><p>Required</p></td>
<td ><p>Must be one of the following:HLS</p><p>SMOOTH</p><p>DASH</p><p>MP4</p><p>MOV</p><p>M4V</p><p></p><p>Provided videos must be unencrypted because there is no encryption support:</p><p>Audio should be as follows:Minimum: first track of Stereo</p><p>Preferred: second track of Dolby (optional)</p></td>
</tr>

</table>
