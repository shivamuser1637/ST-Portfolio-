<script setup>
import { onMounted, onUnmounted, ref } from 'vue'

const menuOpen = ref(false)
const year = new Date().getFullYear()
const progress = ref(0)
const scrollProgress = () => {
  const available = document.documentElement.scrollHeight - window.innerHeight
  progress.value = available > 0 ? window.scrollY / available : 0
}
const closeMenu = () => { menuOpen.value = false }

const experience = [
  {
    role: 'Business Analyst', company: 'AdvantMed India LLP', dates: 'JUL 2022 — PRESENT',
    domains: 'HRMS / HRIS · HEALTHCARE ANALYTICS · P&C INSURANCE (GUIDEWIRE)',
    points: [
      'Led 50+ stakeholder interviews and workshops; translated business needs into technical requirements and delivery plans.',
      'Created 30+ BRD, FRD, and PRD documents, plus RTMs, use cases, user stories, and acceptance criteria.',
      'Managed 200+ prioritized backlog stories in JIRA and facilitated 100+ sprint ceremonies across Agile teams.',
      'Designed 150+ test cases and coordinated UAT, reaching a 98% test pass rate before deployment.',
      'Mapped current and future processes, identifying improvements associated with 30% higher operational efficiency and 25% shorter processing time.',
    ],
  },
  {
    role: 'Business Analyst', company: 'Integrated Resources', dates: 'FEB 2022 — JUL 2022',
    domains: 'HRMS / HRIS · INSURANCE SOLUTIONS',
    points: [
      'Elicited and documented requirements; produced BRDs, FRDs, process flows, and functional specifications.',
      'Supported project planning, resource allocation, Power BI dashboards, UAT scenarios, and data validation.',
      'Worked with delivery teams to refine user stories and track defects through resolution.',
    ],
  },
  {
    role: 'Associate Business Analyst', company: 'Workspend India Private Limited', dates: 'OCT 2021 — FEB 2022',
    domains: 'E-COMMERCE PLATFORM',
    points: [
      'Translated stakeholder needs into functional specifications, user stories, BRDs, FRDs, and process flows.',
      'Analyzed order management, inventory, and customer service workflows to identify process improvements.',
      'Maintained requirements and change records; served as liaison between business and technical teams.',
    ],
  },
  {
    role: 'Project Coordinator', company: 'TaskUs India Private Limited', dates: 'FEB 2021 — OCT 2021',
    domains: 'PROJECT PLANNING · CROSS-FUNCTIONAL DELIVERY',
    points: [
      'Coordinated project plans, milestones, task assignments, deadlines, and deliverable tracking.',
      'Maintained project records, status reports, meeting notes, and action items; escalated schedule and scope risks.',
    ],
  },
  {
    role: 'Sales IT Engineer', company: 'C.R.M. Services India Private Limited', dates: 'JAN 2020 — FEB 2021',
    domains: 'IT SOLUTIONS · PRE-SALES · CLIENT DELIVERY',
    points: [
      'Assessed client needs and translated requirements into technical solutions, proposals, and solution designs.',
      'Delivered product demonstrations and pre-sales support; coordinated implementation, deployment, and user training.',
    ],
  },
]

const skillGroups = [
  { id: '01', title: 'Requirements engineering', tags: ['Elicitation', 'Stakeholder interviews', 'BRD', 'FRD', 'PRD', 'RTM', 'Use cases', 'User stories', 'Acceptance criteria'] },
  { id: '02', title: 'Agile & delivery', tags: ['Agile Scrum', 'Kanban', 'Waterfall', 'SDLC', 'Sprint planning', 'Backlog management', 'JIRA Advanced', 'Azure DevOps', 'MS Project'] },
  { id: '03', title: 'Process & product', tags: ['BPMN', 'Process modeling', 'Gap analysis', 'AS-IS / TO-BE', 'Process optimization', 'Product lifecycle', 'Risk management', 'Change management'] },
  { id: '04', title: 'Data & quality', tags: ['SQL', 'Power BI', 'Google Sheets', 'Advanced Excel', 'UAT', 'Test strategy', 'Test cases', 'Defect tracking', 'Data validation'] },
  { id: '05', title: 'Technical toolkit', tags: ['Python (Basic)', 'Postman API testing', 'Git / GitHub', 'Linux', 'JIRA', 'Confluence', 'Notion'] },
  { id: '06', title: 'Design & documentation', tags: ['MS Visio', 'Draw.io', 'Figma wireframing', 'Lucidchart', 'Excel', 'Word', 'PowerPoint'] },
]

const achievements = [
  { value: '40%', label: 'clearer requirements', note: 'Reduced ambiguity through structured elicitation.' },
  { value: '98%', label: 'UAT pass rate', note: 'Across coordinated user acceptance testing.' },
  { value: '35%', label: 'less reporting effort', note: 'Through reporting process automation.' },
  { value: '95%+', label: 'stakeholder satisfaction', note: 'Maintained through proactive communication.' },
]

const projects = [
  { id: '01', type: 'HRMS / HRIS', title: 'Human Resources Management', accent: '#a896ff', icon: 'people', detail: 'Business analysis and end-to-end product lifecycle management for HRMS solutions, including requirements, process flows, prioritization, UAT, and delivery.', outcome: 'High-priority HRMS module delivered on time and within budget.' },
  { id: '02', type: 'PROPERTY & CASUALTY', title: 'Insurance Solutions · Guidewire', accent: '#6edfd4', icon: 'shield', detail: 'Requirements and process analysis for property and casualty insurance solutions, including insurance claims process gap analysis and workflow improvement.', outcome: 'Process recommendations improved operational efficiency by 30%.' },
  { id: '03', type: 'HEALTHCARE', title: 'Healthcare Appointment Booking System', accent: '#ff9bd5', icon: 'analytics', detail: 'Business analysis for a healthcare appointment booking system, focused on documenting requirements, booking workflows, process flows, and validation with stakeholders.', outcome: 'Healthcare operations improvements reduced recurring errors by 35%.' },
  { id: '04', type: 'E-COMMERCE', title: 'E-Commerce Platform', accent: '#ffc477', icon: 'commerce', detail: 'Business requirements and workflow analysis for order management, inventory, and customer service, supporting platform optimization and automation.', outcome: 'Documented current and proposed processes for platform optimization.' },
]

const techLogos = [
  { name: 'Jira', logo: '/logos/jira.svg', type: 'Delivery', color: '#579dff' },
  { name: 'Confluence', logo: '/logos/confluence.svg', type: 'Knowledge', color: '#6b8cff' },
  { name: 'Notion', logo: '/logos/notion.svg', type: 'Workspace', color: '#e9edf5' },
  { name: 'Azure DevOps', logo: '/logos/azure-devops.png', type: 'Delivery', color: '#44b8ff' },
  { name: 'Power BI', logo: '/logos/powerbi.svg', type: 'Analytics', color: '#ffd45e' },
  { name: 'Figma', logo: '/logos/figma.svg', type: 'Design', color: '#ff7b72' },
  { name: 'MS Visio', logo: '/logos/visio.svg', type: 'Process maps', color: '#77a7ff' },
  { name: 'Draw.io', logo: '/logos/drawio.svg', type: 'Diagrams', color: '#ffaf5e' },
  { name: 'SQL', logo: '/logos/sql.svg', type: 'Data', color: '#6fe0d2' },
  { name: 'Python', logo: '/logos/python.svg', type: 'Basic', color: '#ffe071' },
  { name: 'Postman', logo: '/logos/postman.svg', type: 'API testing', color: '#ff966c' },
  { name: 'GitHub', logo: '/logos/github.svg', type: 'Version control', color: '#d8dcf1' },
]

onMounted(() => window.addEventListener('scroll', scrollProgress, { passive: true }))
onUnmounted(() => window.removeEventListener('scroll', scrollProgress))
</script>

<template>
  <div class="site-shell technical-shell">
    <div class="scene-layer" aria-hidden="true"><span class="scene-orb orb-a"></span><span class="scene-orb orb-b"></span><span class="scene-orb orb-c"></span><span class="scene-ring ring-a"></span><span class="scene-ring ring-b"></span></div>
    <div class="scroll-line" :style="{ transform: `scaleX(${progress})` }"></div>
    <header class="topbar">
      <a class="brand" href="#home" @click="closeMenu"><span class="brand-mark"><img src="/shivam-logo.png" alt="" /></span><span>SHIVAM TRIPATHI <b class="brand-slash">/</b> BA.ENGINEER</span></a>
      <button class="menu-toggle" @click="menuOpen = !menuOpen" :aria-expanded="menuOpen" aria-label="Toggle navigation"><span></span><span></span></button>
      <nav :class="menuOpen ? 'nav-links open' : 'nav-links'" aria-label="Resume navigation">
        <a href="#profile" @click="closeMenu">Profile</a><a href="#experience" @click="closeMenu">Experience</a><a href="#projects" @click="closeMenu">Projects</a><a href="#stack" @click="closeMenu">Toolkit</a><a href="#education" @click="closeMenu">Education</a>
        <a class="nav-contact" href="#contact" @click="closeMenu">Connect <span>↗</span></a>
      </nav>
    </header>

    <main>
      <section id="home" class="hero section-wrap technical-hero">
        <div class="hero-copy">
          <div class="eyebrow"><i></i> BUSINESS ANALYST <span>·</span> INDORE, INDIA</div>
          <div class="hero-overline">SYSTEM PROFILE <span>ST-BA-005</span></div>
          <h1>Business needs<br />to <span class="accent">technical</span><br />solutions<span class="accent">.</span></h1>
          <p class="hero-lede">5+ years translating complex business requirements into structured, testable, delivery-ready solutions across HRMS, healthcare, insurance, and e-commerce.</p>
          <div class="hero-actions"><a class="button button-primary" href="#experience">View experience <span>↓</span></a><a class="text-link" href="mailto:shivam.usertripathi012@gmail.com">Email <span>↗</span></a></div>
          <div class="hero-foot"><span>RESUME PROFILE / 2026</span><span class="scroll-mark">↓</span><span class="hero-foot-line"></span><span>01 / 06</span></div>
        </div>
        <div class="hero-art technical-art" aria-label="Shivam Tripathi logo and animated technical data visualization">
          <div class="art-glow"></div><div class="orbit orbit-one"></div><div class="orbit orbit-two"></div>
          <div class="data-cube"><div class="cube-face cube-front"><span class="face-label">REQ. COVERAGE / 01</span><div class="cube-bars"><i></i><i></i><i></i><i></i><i></i><i></i><i></i></div><span class="face-foot">BUSINESS → DELIVERY</span></div><div class="cube-face cube-back"></div><div class="cube-face cube-right"><span>↗</span></div><div class="cube-face cube-left"></div><div class="cube-face cube-top"></div><div class="cube-face cube-bottom"></div></div>
          <figure class="portrait-card"><div class="portrait-frame"><img src="/shivam-logo.png" alt="Shivam Tripathi logo" /></div></figure>
          <div class="art-label label-top"><span>FIG. 01</span><span>ANALYSIS SYSTEM</span></div><div class="art-label label-bottom"><span class="live-dot"></span><span>DATA / REQUIREMENTS / DELIVERY</span><span>— 001</span></div><div class="art-cross cross-a">+</div><div class="art-cross cross-b">+</div>
          <div class="orbit-readout"><span>EXPERIENCE</span><strong>05<span>+</span></strong><small>YEARS</small></div>
        </div>
      </section>

      <section id="profile" class="intro section-wrap">
        <div class="section-kicker"><span>01</span> / PROFESSIONAL SUMMARY</div>
        <div class="intro-body"><h2>Bridging the gap<br />between business<br />and <em>technology.</em></h2><div class="intro-text"><p>Results-driven Business Analyst with 5+ years of progressive experience in requirements gathering, business process analysis, and Agile project delivery.</p><p>Skilled at creating BRD, FRD, PRD, and RTM documentation, facilitating stakeholder collaboration, and turning complex business needs into actionable technical specifications. Experienced across product lifecycles, UAT, process improvement, and cross-functional delivery.</p></div></div>
        <div class="principle-row"><span>DISCOVER</span><span class="principle-line"></span><span>SPECIFY</span><span class="principle-line"></span><span>VALIDATE</span><span class="principle-line"></span><span>DELIVER</span></div>
      </section>

      <section id="experience" class="journey section-wrap technical-experience">
        <div class="section-heading"><div class="section-kicker"><span>02</span> / PROFESSIONAL EXPERIENCE</div><p>Progressive ownership<br />across five roles.</p></div>
        <div class="experience-list">
          <article v-for="(job, index) in experience" :key="job.company" class="experience-card">
            <div class="experience-marker"><span>{{ String(index + 1).padStart(2, '0') }}</span><i></i></div>
            <div class="experience-main"><div class="experience-head"><div><h3>{{ job.role }}</h3><div class="company-name">{{ job.company }}</div></div><time>{{ job.dates }}</time></div><div class="project-line">{{ job.domains }}</div><ul><li v-for="point in job.points" :key="point">{{ point }}</li></ul></div>
          </article>
        </div>
      </section>

      <section id="projects" class="projects-section section-wrap">
        <div class="section-heading"><div class="section-kicker"><span>03</span> / PROJECTS &amp; DOMAINS</div><p>Business challenges<br />across four domains.</p></div>
        <div class="projects-grid">
          <article v-for="project in projects" :key="project.id" class="project-card" :style="{ '--project-accent': project.accent }">
            <div class="project-card-head"><span class="project-index">PROJECT / {{ project.id }}</span><span class="project-type">{{ project.type }}</span></div>
            <div class="project-logo" aria-hidden="true">
              <svg v-if="project.icon === 'people'" viewBox="0 0 80 80"><circle cx="29" cy="27" r="10"/><circle cx="53" cy="31" r="8"/><path d="M10 62c0-12 8-20 19-20s19 8 19 20v4H10z"/><path d="M47 47c3-3 7-5 12-5 9 0 15 7 15 17v7H54"/></svg>
              <svg v-else-if="project.icon === 'shield'" viewBox="0 0 80 80"><path d="M40 8 65 18v18c0 17-10 29-25 37C25 65 15 53 15 36V18z"/><path d="m28 40 8 8 17-19"/></svg>
              <svg v-else-if="project.icon === 'analytics'" viewBox="0 0 80 80"><path d="M13 66V43h13v23M34 66V30h13v36M55 66V15h13v51"/><path d="m13 32 18-12 14 5 21-15"/></svg>
              <svg v-else viewBox="0 0 80 80"><path d="M12 17h9l8 37h34l8-27H26"/><circle cx="36" cy="65" r="4"/><circle cx="59" cy="65" r="4"/><path d="M37 38h25M49 26v25"/></svg>
              <span class="logo-orbit orbit-a"></span><span class="logo-orbit orbit-b"></span>
            </div>
            <h3>{{ project.title }}</h3><p class="project-description">{{ project.detail }}</p>
            <div class="project-outcome"><span>DELIVERY NOTE</span><p>{{ project.outcome }}</p></div>
            <span class="project-card-glow"></span>
          </article>
        </div>
      </section>

      <section class="impact-section section-wrap">
        <div class="section-heading"><div class="section-kicker"><span>04</span> / SELECTED OUTCOMES</div><p>Measured improvements<br />from the resume.</p></div>
        <div class="impact-grid"><article v-for="(item, index) in achievements" :key="item.value" class="impact-card"><div class="impact-top"><span>METRIC / 0{{ index + 1 }}</span><span class="metric-dot"></span></div><strong>{{ item.value }}</strong><h3>{{ item.label }}</h3><p>{{ item.note }}</p></article></div>
        <div class="impact-foot"><span>DELIVERED HIGH-PRIORITY HRMS PRODUCT</span><span>ON TIME · WITHIN BUDGET · BUSINESS OBJECTIVES MET</span></div>
      </section>

      <section id="stack" class="skills-section section-wrap technical-stack">
        <div class="section-heading"><div class="section-kicker"><span>05</span> / TECHNICAL PROFICIENCIES</div><p>Methods, tools, and<br />analysis disciplines.</p></div>
        <div class="skills-grid"><article v-for="group in skillGroups" :key="group.id" class="skills-card"><div class="card-index">{{ group.id }} <span>TOOLSET</span></div><h3>{{ group.title }}</h3><div class="skill-list"><span v-for="item in group.tags" :key="item">{{ item }}</span></div></article></div>
        <div class="domain-footer"><span>DOMAIN EXPERTISE</span><span>HRMS / HRIS</span><span>HEALTHCARE</span><span>PROPERTY &amp; CASUALTY / GUIDEWIRE</span><span>E-COMMERCE</span></div>
      </section>

      <section class="logo-wall-section section-wrap">
        <div class="section-heading"><div class="section-kicker"><span>06</span> / TECH TOOLBOX</div><p>Tools behind the<br />analysis and delivery.</p></div>
        <div class="logo-wall"><article v-for="tool in techLogos" :key="tool.name" class="logo-tile" :style="{ '--brand': tool.color }"><img class="tech-logo-image" :src="tool.logo" :alt="tool.name + ' logo'"><span class="logo-name">{{ tool.name }}</span><span class="logo-type">{{ tool.type }}</span><i class="logo-glint"></i></article></div>
      </section>

      <section id="education" class="education-section section-wrap">
        <div class="section-heading"><div class="section-kicker"><span>07</span> / EDUCATION &amp; DEVELOPMENT</div><p>Engineering foundation.<br />Continuous learning.</p></div>
        <div class="education-grid">
          <article class="education-card"><div class="education-level">B.TECH <span>01</span></div><h3>Bachelor of Technology</h3><p>Mechanical Engineering · 7.9 / 10 CGPA</p><div class="education-school">Prestige Institute of Engineering Management and Research<br />Indore, Madhya Pradesh</div></article>
          <article class="education-card"><div class="education-level">DIPLOMA <span>02</span></div><h3>Diploma</h3><p>Mechanical Engineering · 7.5 / 10 CGPA</p><div class="education-school">Prestige Institute of Engineering Management and Research<br />Indore, Madhya Pradesh</div></article>
        </div>
        <div class="cert-grid"><div class="cert-title">PROFESSIONAL DEVELOPMENT <span>//</span></div><div class="cert-row"><span>Agile Business Analysis Training</span><b>COMPLETED</b></div><div class="cert-row"><span>SQL for Data Analysis</span><b>ADVANCED CERTIFICATION</b></div><div class="cert-row"><span>Certified Scrum Master (CSM)</span><b>IN PROGRESS</b></div><div class="cert-row"><span>CBAP</span><b>PREPARATION</b></div></div>
      </section>

      <section id="contact" class="contact section-wrap technical-contact"><div class="section-kicker"><span>08</span> / CONTACT</div><div class="contact-layout"><div><h2>Open to the<br />next <em>challenge.</em></h2><p class="contact-copy">Business analysis · Agile delivery · Requirements engineering · Project coordination</p><a class="contact-email" href="mailto:shivam.usertripathi012@gmail.com">shivam.usertripathi012@gmail.com <span>↗</span></a><a class="contact-phone" href="tel:+919893160345">+91 98931 60345</a><p class="contact-location">INDORE, MADHYA PRADESH, INDIA</p></div><div class="contact-panel"><span class="panel-prompt">&gt; PROFILE.STATUS</span><strong>AVAILABLE FOR OPPORTUNITIES</strong><span class="panel-prompt">&gt; PRIMARY FOCUS</span><strong>BUSINESS ANALYSIS / PRODUCT DELIVERY</strong><span class="panel-prompt">&gt; LOCATION</span><strong>INDORE, IN</strong><span class="panel-caret">_</span></div></div></section>
      <section id="complete-resume" class="section-wrap full-resume">
        <div class="section-heading"><div class="section-kicker"><span>09</span> / COMPLETE RESUME</div><p>Full career record<br />and supporting details.</p></div>
        <article class="full-resume-card">
          <h2>Professional Summary</h2>
          <p>Results-driven Business Analyst with 5+ years of progressive experience in requirements gathering, business process analysis, and Agile project delivery across HRMS, Healthcare, Insurance, and E-commerce domains. Proven expertise in creating comprehensive documentation (BRD, FRD, PRD, RTM), facilitating stakeholder collaboration, and translating complex business needs into actionable technical specifications. Skilled in Agile/Scrum methodologies with hands-on experience using JIRA, Confluence, and analytical tools. Strong track record of bridging business-technology gaps, driving process improvements, and delivering solutions that align with organizational objectives. Adept at managing end-to-end product lifecycles, conducting UAT, and fostering cross-functional team collaboration to ensure successful project outcomes.</p>
          <h2>Core Competencies</h2>
          <ul><li>Requirements Gathering &amp; Elicitation</li><li>Stakeholder Management</li><li>Business Process Analysis</li><li>Documentation (BRD, FRD, PRD, RTM, Use Cases, User Stories)</li><li>Gap Analysis</li><li>Process Modeling</li><li>Agile/Scrum Methodologies</li><li>Sprint Planning &amp; Backlog Management</li><li>User Acceptance Testing (UAT)</li><li>Data Analysis &amp; Validation</li><li>Reporting &amp; Visualization (Power BI)</li><li>Quality Assurance</li><li>Risk Management &amp; Mitigation</li><li>Change Management</li><li>Process Improvement &amp; Optimization</li><li>Cross-Functional Collaboration</li><li>Product Lifecycle Management</li><li>Solution Design &amp; Validation</li></ul>
          <h2>Technical Proficiencies</h2>
          <ul><li><b>Project Management Tools:</b> JIRA (Advanced), Confluence, Notion, MS Project, Azure DevOps</li><li><b>Documentation &amp; Design:</b> MS Visio, Draw.io, Figma (Wireframing), Lucidchart, MS Office Suite (Advanced Excel, Word, PowerPoint)</li><li><b>Analytics &amp; Visualization:</b> Power BI, Google Sheets, Excel (Pivot Tables, VLOOKUP, Advanced Formulas)</li><li><b>Methodologies:</b> Agile Scrum, Waterfall, Kanban, SDLC, Business Process Modeling (BPMN)</li><li><b>Technical Knowledge:</b> SQL (Data Querying &amp; Analysis), Python (Basic), Postman (API Testing), Git/GitHub, Linux</li><li><b>Testing &amp; Quality:</b> UAT, Test Case Development, Defect Tracking, Test Matrix, Quality Assurance</li><li><b>Domain Expertise:</b> HRMS/HRIS, Healthcare, Property &amp; Casualty Insurance (Guidewire), E-commerce</li></ul>
          <h2>AdvantMed India LLP | Business Analyst | July 2022 – Present</h2><p><b>Projects:</b> HRMS/HRIS, Property &amp; Casualty Insurance (Guidewire), Healthcare Analytics</p>
          <h3>Requirements Management &amp; Documentation</h3><ul><li>Led requirements gathering sessions with diverse stakeholders across HRMS, Healthcare, and Insurance domains, conducting 50+ interviews and workshops to capture comprehensive business needs</li><li>Developed 30+ detailed Business Requirement Documents (BRD), Functional Requirement Documents (FRD), and Product Requirement Documents (PRD) ensuring alignment with business objectives and technical feasibility</li><li>Created comprehensive Requirements Traceability Matrix (RTM) linking business requirements to test cases, ensuring 100% requirement coverage and validation</li><li>Prepared detailed use cases, user stories, and acceptance criteria with clear definition of done, reducing ambiguity by 40% and improving development efficiency</li><li>Designed process flow diagrams, data flow diagrams, and system architecture diagrams using MS Visio and Draw.io to visualize complex business processes</li></ul>
          <h3>Agile Delivery &amp; Project Coordination</h3><ul><li>Facilitated 100+ sprint planning sessions, daily stand-ups, sprint reviews, and retrospectives as Scrum team member, ensuring Agile best practices and continuous improvement</li><li>Managed product and sprint backlogs in JIRA, prioritizing 200+ user stories based on business value, technical dependencies, and resource capacity</li><li>Performed regular backlog grooming and refinement sessions, breaking down into epics, user stories, story point estimation and clear acceptance criteria</li><li>Tracked project progress through JIRA dashboards and burn-down charts, providing real-time visibility into sprint velocity, blockers, and completion metrics</li><li>Coordinated with embedded systems and software development teams to ensure seamless integration and timely delivery of product features</li></ul>
          <h3>Stakeholder Engagement &amp; Communication</h3><ul><li>Served as primary liaison between business stakeholders, technical teams, and senior management, ensuring alignment of project objectives and transparent communication</li><li>Conducted weekly status meetings and prepared executive-level presentations and reports highlighting project progress, risks, and mitigation strategies</li><li>Established strong relationships with key clients, addressing concerns proactively and maintaining 95% stakeholder satisfaction rating</li><li>Facilitated requirement clarification sessions with development teams, resolving 100+ technical queries and ensuring shared understanding of business logic</li><li>Collaborated with marketing, product development, and sales departments to align project deliverables with overall company strategy and market needs</li></ul>
          <h3>Business Process Analysis &amp; Improvement</h3><ul><li>Conducted comprehensive gap analysis identifying inefficiencies in existing HRMS and insurance claims processes, recommending solutions that improved operational efficiency by 30%</li><li>Mapped current state (AS-IS) and future state (TO-BE) business processes, creating detailed process flows that streamlined workflows and reduced processing time by 25%</li><li>Performed root cause analysis on recurring issues in healthcare operations, implementing process improvements that reduced errors by 35%</li><li>Identified automation opportunities in manual processes, working with technical teams to implement solutions saving 20+ hours weekly</li></ul>
          <h3>Testing, Quality Assurance &amp; Risk Management</h3><ul><li>Designed comprehensive test strategies and developed 150+ test cases covering functional, integration, and regression testing scenarios</li><li>Led User Acceptance Testing (UAT) coordination with business users, achieving 98% test pass rate before production deployment</li><li>Conducted risk analysis workshops identifying potential project risks, developing mitigation strategies that prevented 85% of anticipated issues</li><li>Tracked defects in JIRA with clear severity classification and priority assignment, ensuring critical issues were resolved within SLA</li><li>Validated data accuracy during requirement testing and implementation phases, ensuring compliance with business rules and regulatory requirements</li></ul>
          <h3>Product Lifecycle &amp; Resource Management</h3><ul><li>Managed end-to-end product lifecycle for high-priority HRMS module from conception through launch, delivering on time and within budget</li><li>Developed product roadmaps and feature prioritization frameworks based on business value, technical feasibility, and market demands</li><li>Created and maintained resource allocation matrix optimizing team capacity and workload distribution across multiple concurrent projects</li><li>Monitored team execution and performance metrics, implementing corrective actions to keep projects on track and meet key business objectives</li></ul>
          <h2>Integrated Resources | Business Analyst | February 2022 – July 2022</h2><p><b>Projects:</b> HRMS/HRIS, Insurance Solutions</p><ul><li>Collaborated with business stakeholders to elicit, analyze, and document detailed business requirements for HRMS and insurance platform enhancements</li><li>Prepared comprehensive BRD, FRD, and process flow diagrams ensuring clear communication of business logic and technical specifications</li><li>Developed detailed project plans including scope definition, deliverables timeline, and resource allocation under guidance of senior project managers</li><li>Supported data-driven decision-making through analytics and visualization tools, creating dashboards in Power BI for business intelligence</li><li>Assisted in developing test cases and UAT scenarios, participating in testing activities to ensure solutions met defined business requirements</li><li>Tracked defects through resolution lifecycle in collaboration with development teams, ensuring timely closure of issues</li><li>Worked with development teams to ensure user stories were well-defined, properly estimated, and ready for implementation</li><li>Validated data accuracy during requirement testing, maintaining data integrity standards and business rule compliance</li></ul>
          <h2>Workspend India Private Limited | Associate Business Analyst | October 2021 – February 2022</h2><p><b>Project:</b> E-Commerce Platform</p><ul><li>Gathered and documented business requirements from e-commerce stakeholders, translating client needs into functional specifications and user stories</li><li>Conducted gap analysis identifying process improvement opportunities in order management, inventory, and customer service workflows</li><li>Prepared BRD, FRD, and process flow diagrams documenting current and proposed business processes for platform optimization</li><li>Analyzed existing workflows and proposed optimized business processes supporting process automation and efficiency initiatives</li><li>Maintained up-to-date project documentation including requirements, change requests, and progress tracking reports</li><li>Acted as liaison between business and technical teams ensuring alignment on project objectives and deliverables</li><li>Analyzed business data to identify trends, issues, and improvement opportunities in e-commerce operations</li><li>Participated in stakeholder meetings providing analytical insights and clarifying business requirements</li></ul>
          <h2>TaskUs India Private Limited | Project Coordinator | February 2021 – October 2021</h2><ul><li>Assisted Project Managers in developing detailed project plans, timelines, work breakdown structures, and milestone definitions</li><li>Coordinated cross-functional teams ensuring effective task assignment, deadline communication, and deliverable tracking</li><li>Served as central point of contact between stakeholders, team members, and management facilitating smooth communication flow</li><li>Maintained comprehensive project documentation including plans, progress reports, meeting minutes, and action item tracking</li><li>Tracked project progress monitoring adherence to timelines, scope, and budget while identifying and escalating risks</li><li>Prepared project status reports and presentations for management review ensuring transparency and informed decision-making</li><li>Facilitated project meetings, prepared agendas, documented minutes, and tracked action items through completion</li></ul>
          <h2>C.R.M. Services India Private Limited | Sales IT Engineer | January 2020 – February 2021</h2><ul><li>Engaged with clients to understand technical and business requirements through site visits, assessments, and feasibility studies</li><li>Translated customer requirements into technical solutions aligned with company IT offerings and business objectives</li><li>Provided pre-sales technical assistance delivering product demonstrations and technical presentations showcasing IT solutions</li><li>Designed customized IT solutions preparing technical proposals, solution architectures, and detailed quotations</li><li>Collaborated with product, engineering, and procurement teams to finalize technical solutions and ensure successful delivery</li><li>Provided post-sale support including configuration, deployment, user training, and ongoing technical assistance</li></ul>
          <h2>Key Achievements</h2><ul><li>Successfully delivered high-priority HRMS product within aggressive timeline achieving all key business objectives and stakeholder satisfaction</li><li>Improved requirements clarity and completeness by 40% through structured elicitation techniques reducing development rework</li><li>Reduced manual reporting effort by 35% through process automation and streamlined workflows</li><li>Achieved 98% UAT pass rate through comprehensive test strategy development and stakeholder collaboration</li><li>Maintained 95%+ stakeholder satisfaction rating through proactive communication and expectation management</li><li>Created 30+ comprehensive BRD/FRD documents serving as foundation for successful project implementations</li><li>Led cross-functional teams fostering collaborative work environment resulting in improved team productivity and project delivery</li></ul>
          <h2>Education</h2><ul><li>Bachelor of Technology (B.Tech) in Mechanical Engineering | CGPA: 7.9/10</li><li>Prestige Institute of Engineering Management and Research, Indore, Madhya Pradesh</li><li>Diploma in Mechanical Engineering | CGPA: 7.5/10</li><li>Prestige Institute of Engineering Management and Research, Indore, Madhya Pradesh</li></ul>
          <h2>Professional Development</h2><ul><li>Certified Scrum Master (CSM) – In Progress</li><li>CBAP (Certified Business Analysis Professional) – Preparation</li><li>Agile Business Analysis Training – Completed</li><li>SQL for Data Analysis – Advanced Certification</li></ul>
          <h2>Additional Information</h2><ul><li>Strong analytical and problem-solving abilities with systematic approach to complex business challenges</li><li>Excellent communication skills with proven ability to present technical concepts to non-technical stakeholders</li><li>Experience working in fast-paced Agile environments managing multiple concurrent projects and priorities</li><li>Demonstrated leadership in cross-functional team settings fostering collaboration and high performance</li><li>Continuous learner staying current with industry trends, BA best practices, and emerging technologies</li></ul>
        </article>
      </section>    </main>
    <footer class="footer section-wrap"><a class="brand" href="#home"><span class="brand-mark"><img src="/shivam-logo.png" alt="" /></span><span>SHIVAM TRIPATHI <b class="brand-slash">/</b> BUSINESS ANALYST</span></a><span>© {{ year }} — TECHNICAL RESUME</span><a href="#home">BACK TO TOP ↑</a></footer>
  </div>
</template>






